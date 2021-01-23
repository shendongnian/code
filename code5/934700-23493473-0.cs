    public abstract class Log<TLogWriter> where TLogWriter : LogWriter
    {
        public virtual bool AppendLog
        {
            set { _logWriter.Append = value; }
        }
    
        internal TLogWriter _logWriter;
    
        public abstract void AddEntry(string input);
    }
    
    public class SyncLog : Log<SyncLogWriter>
    {
        public SyncLog
        {
            _logWriter = new SyncLogWriter(); 
        }
    
        public override void AddEntry(string input)
        {
            content.AddEntry(input);
            _logWriter.Write("Hello");
        }
    }
