    // My main abstract class
    public abstract class Log
    {
        public virtual bool AppendLog
        {
            set { _logWriter.Append = value; }
        }
        internal LogWriter _logWriter; //LogWriter is another abstract class
        public abstract void AddEntry(string input);
    }
    // Implementation of abstract class
    public class SyncLog : Log
    {
        private SyncLogWriter _syncLogWriter
        public SyncLog
        {
            // Now I want to initialize LogWriter abstract class in parent with
            // It's actual implementation SyncLogWriter : LogWriter
            _syncLogWriter = new SyncLogWriter(); 
            _logWriter = _syncLogWriter
        }
        public override void AddEntry(string input)
        {
            content.AddEntry(input);
            _syncLogWriter.Write("Hello");
        }
    }
