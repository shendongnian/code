    public class SyncLog : Log
    {
        public SyncLog
        {
            _logWriter = new SyncLogWriter(); 
        }
    
        private SyncLogWriter LogWriter
        {
            get { return (SyncLogWriter)_logWriter; }
        }
    
        public override void AddEntry(string input)
        {
            content.AddEntry(input);
            _logWriter.Write("Hello");
        }
    
        private void DoSomething()
        {
             LogWriter.SomeSyncLogWriterMethod();
        }
    }
