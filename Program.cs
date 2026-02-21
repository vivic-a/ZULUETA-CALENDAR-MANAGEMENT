using System;
namespace CalendarManagement;
class CalendarEvent
{
    public string Title { get; set; }
    public DateTime Date { get; set; }

    public CalendarEvent(string title, DateTime date)
    {
        Title = title;
        Date = date;
    }
}

class Program
{
    static List<CalendarEvent> events = new List<CalendarEvent>();

    static void Main()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n=== Simple Student Calendar ===");
            Console.WriteLine("1. Add Event");
            Console.WriteLine("2. View Events");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddEvent();
                    break;
                case "2":
                    ViewEvents();
                    break;
                case "3":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice, try again.");
                    break;
            }
        }
    }

    static void AddEvent()
    {
        Console.Write("Enter event title: ");
        string title = Console.ReadLine();

        Console.Write("Enter date (yyyy-mm-dd): ");
        string dateInput = Console.ReadLine();

        if (DateTime.TryParse(dateInput, out DateTime date))
        {
            events.Add(new CalendarEvent(title, date));
            Console.WriteLine("Event added!");
        }
        else
        {
            Console.WriteLine("Invalid date format. Try again.");
        }
    }

    static void ViewEvents()
    {
        if (events.Count == 0)
        {
            Console.WriteLine("No events yet!");
            return;
        }

        Console.WriteLine("\nYour Events:");
        foreach (var ev in events)
        {
            Console.WriteLine($"{ev.Date.ToShortDateString()} - {ev.Title}");
        }
    }
}