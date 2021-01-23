    public class EventController : ApiController
    {
        [HttpGet]
        [Route("event/thisweek")]
        public List<HobbsEventsMobile.Models.Event> ICanNameThisWhateverIWant()
        {
            return HobbsEventsMobile.Models.Event.GetThisWeeksEvents();
        }
    }
