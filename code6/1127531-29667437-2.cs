    [DataContract]
    class EventResponse{
       public int Value {get;set;}
    }
    public IEnumerable<EventResponse> RetrieveAllEvent() 
        {
            return context.EventSet.Select(f=>new EventResponse { Value = f.Value }).ToList();
        }
