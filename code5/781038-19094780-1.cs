    public string getEventName(int eventId,params int[] orgId)
    {
         return eventList.Where(x=>
                                  x.EventId==eventId && 
                                   orgId.Any(y=>y==x.OrgID))
                         .Select(x.EventName)
                         .Single();
      
    }
