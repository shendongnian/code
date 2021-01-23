    public class EventLogEngine
    {
        private string _sourceName, _logName;
        public EventLogEngine(string sourceName, string logName)
        {
            if (!EventLog.SourceExists(sourceName))
                EventLog.CreateEventSource(sourceName, logName);
            _sourceName = sourceName; _logName = logName;
        }
        public void WriteLog(string message, EventLogEntryType eventType, int Id)
        {
            EventLog.WriteEntry(_sourceName, message, eventType, Id);
        }
    }
    protected override void OnStart(string[] args)
    {
     EventLogEngine eventWriter = new EventLogEngine("mySource","myLog");
    eventWriter.WriteLog("sourceName","Service started",EventLogEntryType.Information,"anyId");
    }
