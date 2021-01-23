    public static void Main()
    {
        var count = Int32.Parse(Console.ReadLine());
        Console.Write("Logger Type -->");
        var logType = Console.ReadLine();
        ILogger logger = logType == "A" ? (ILogger)new LoggerTypeA() : new LoggerTypeB();
        if (count > 10)
        {
            logger.Error(count);
        }
        else
        {
            logger.Warning(count);
        }
    
        Console.ReadLine();
    }
    public interface ILogger
    {
        void Error(int count);
        void Warning(int count);
    }
    internal class LoggerTypeA : ILogger
    {
        public void Error(int count)
        {
            Console.WriteLine("Error {0} from Logger A", count);
        }
    
        public void Warning(int count)
        {
            Console.WriteLine("Warning {0} from Logger A", count);
        }
    }
    
    internal class LoggerTypeB : ILogger
    {
        public void Error(int count)
        {
            Console.WriteLine("Error {0} from Logger B", count);
        }
    
        public void Warning(int count)
        {
            Console.WriteLine("Warning {0} from Logger ", count);
        }
    }
