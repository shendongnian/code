    using log4net;
    using log4net.Config;
    
    public class LogTest
    {
        private static readonly ILog logger = 
               LogManager.GetLogger(typeof(LogTest));
        
        static void Main(string[] args)
        {
            BasicConfigurator.Configure();
            
            logger.Debug("Here is a debug log.");
            logger.Info("... and an Info log.");
            logger.Warn("... and a warning.");
            logger.Error("... and an error.");
            logger.Fatal("... and a fatal error.");
        }
    }
.
    private static readonly ILog logger = 
              LogManager.GetLogger(typeof(LogTest));
