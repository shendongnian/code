    public class EventViewer()
    {
    	EventLog _eventlog;
    
    	public void createandreferenceEventViewer(string sLogNameTrimmed)
    	{
                //Creates or reference the default Event Viewer
                if (!EventLog.SourceExists(sLogNameTrimmed))
                {                
                    EventLog.CreateEventSource(sLogNameTrimmed, sLogNameTrimmed);
                    Thread.Sleep(500); // Event viewer need latency to allow being written 
                }
                // Connect to the newly created / existing Log
                _eventlog = new EventLog(sLogNameTrimmed);
                _eventlog.Source = sLogNameTrimmed;
                _eventlog.EntryWritten += WrittenEntryEventHandler;
                _eventlog.EnableRaisingEvents = true;
    	}
    
    	void WrittenEntryEventHandler(object source, EntryWrittenEventArgs e)
            {
                switch (e.Entry.EntryType)
                {
                    case EventLogEntryType.Error:
                        	DO_ERROR_HANDLING_HERE();
                        break;
                    case EventLogEntryType.Warning :
                        	DO_WARNING_HANDLING_HERE();
                        break;
                    default:
                        DO_DEFAULT_HANDLING_HERE();
                        break;
                }
            }
    }
