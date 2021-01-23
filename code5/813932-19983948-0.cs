    public class Logger
    {
        private static Logger logger = new Logger();
        private Logger() { }
        public static Logger Instance
        {
            get
            {
                return logger;
            }
        }
        public void Log(text)
        {
            // Logging text
        }
        public int Mode { get; set; }
    }
