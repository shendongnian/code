    public class LogTest
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(LogTest));
        
        static void Main(string[] args)
        {
            logger.Error("an error!");
        }
    }
