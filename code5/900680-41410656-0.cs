    public class LocalDB
    {
        public LocalDB(int sessionID, string eventName)
        {
            SessionID = sessionID;
            EventName = eventName;
        }
    
        public int SessionID { get; }
        public string EventName { get; }
        public DateTime TimeCreate { get; } = DateTime.UtcNow;
    }
    
    public class Other
    {
        public void DoSomething()
        {
            NewEvent = new LocalDB(1, "Other Event");
        }
    
        public LocalDB NewEvent { get; private set; }
    }
