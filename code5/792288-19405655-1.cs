    internal class LoggerTypeA : ILogger
    {
        public static void Error(int count)
        {
            Console.WriteLine("Error {0} from Logger A", count);
        }
        void ILogger.Error(int count)
        {
            Error(count);
        }
    
        public static void Warning(int count)
        {
            Console.WriteLine("Warning {0} from Logger A", count);
        }
        void ILogger.Warning(int count)
        {
            Warning(count);
        }
    }
