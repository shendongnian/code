    // My main abstract class
    public abstract class Log
    {
        protected Log(LogWriter logWriter)
        {
            _logWriter = logWriter;
        }
        public virtual bool AppendLog
        {
            set { _logWriter.Append = value; }
        }
        private LogWriter _logWriter; //LogWriter is another abstract class
        public abstract void AddEntry(string input);
    }
    // Implementation of abstract class
    public class SyncLog : Log
    {
        private SyncLogWriter _syncLogWriter
        public SyncLog() : this(new SyncLogWriter()) { }
        private SyncLog(SyncLogWriter logWriter) : base(logWriter)
        {
            _syncLogWriter = logWriter; 
        }
        public override void AddEntry(string input)
        {
            content.AddEntry(input);
            _syncLogWriter.Write("Hello");
        }
    }
