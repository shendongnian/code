    namespace WebAPI.Controllers
    {
        public class EventsController
        {
            [HttpGet]
            public JsonResult Index()
            {
                var event = new EventsModel();
    
                // populate the event from the database here
    
                return Json(event, JsonRequestBehavior.AllowGet);
            }
        }
    }
