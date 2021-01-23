    static void Main()
    {
        var logger = new Logger();
        logger.Log("Log Initialized");
        var MyEventThrower = new EventThrower();
        MyEventThrower.Event += (sender, _) => logger.Log(Convert.ToString(sender));
        MyEventThrower.RaiseEvent();
    }
    public class Logger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
