    internal class Program
    {
        private static void OnExit()
        {
            Console.WriteLine("Exiting from app");
            Console.ReadKey();
        }
        private static void OnCommand(string command)
        {
            Console.WriteLine("Command {0} entered", command);
        }
        private static void Main(string[] args)
        {
            var listener = new ConsoleReader();
            listener.OnQuit += OnExit;
            listener.OnCommandEntered += OnCommand;
            listener.StartReading();
        }
    }
