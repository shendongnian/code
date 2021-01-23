    public class EventController : ApiController
    {
        [HttpGet]
        public List<HobbsEventsMobile.Models.Event> ThisWeek()
        {
            return HobbsEventsMobile.Models.Event.GetThisWeeksEvents();
        }
    }
