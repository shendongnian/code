    class Program
    {
        static void Main(string[] args)
        {
            AttendanceLogger logger = new AttendanceLogger();
            DelegateEvent dEvent = new DelegateEvent();
            dEvent.EventLog += new DelegateEvent.AttendanceLogHandler(logger.LogMessage);
            dEvent.LogProcess();
        }
    }
    class DelegateEvent
    {
        public delegate void AttendanceLogHandler(string message);
        public event AttendanceLogHandler EventLog;
        public void LogProcess()
        {
            EventLog("Delegate Event Called");
        }
    }
    class AttendanceLogger
    {
        public AttendanceLogger() { }
        public void LogMessage(string message)
        {
            Console.WriteLine("AttendanceLogger: " + message);
        }
        private string m_logFile;
    }
