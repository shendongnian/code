    [Route("/event", "POST")]
    public class EventRequest : IReturn<EventResponse>
    {
        public int event_id { get; set; }
    }
