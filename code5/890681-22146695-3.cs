    public class EventService : Service
    {
        public EventResponse Post(EventRequest event_request)
        {
            return new EventResponse() {
                 name = "FirstEvent"
            }
        }
    }
