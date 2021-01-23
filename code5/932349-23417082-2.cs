    public class EventController : ApiController
    {
        public ActionResult Events()
        {
            return HobbsEventsMobile.Models.Event.GetEventSummary();
        }
    }
 
