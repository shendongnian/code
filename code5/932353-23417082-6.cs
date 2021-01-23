    public class EventController : ApiController
    {
        public object Events()
        {
            return HobbsEventsMobile.Models.Event.GetEventSummary();
        }
    }
