    private class ReturnResponse
        {
            public string result, sessionId;
            public EventList eventList;
        }
    
    public class EventList
    {
      public List<string> eventIDs {get;set;}
      public List<string> eventNames {get;set;}
    }
