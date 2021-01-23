    [DataContract]
    class EventResponse{
       public int Value {get;set;}
    }
    public IQueryable<Event> RetrieveAllEvent() 
        {
            return context.EventSet.Select(f=>new EventResponse { Value = f.Value });
        }
