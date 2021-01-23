    [Authorize]
    public class SessionController : Controller {
    
        [HttpGet]
        public JsonResult Get() {
            return Json(Helpers.Context.CurrentSession.ID);
        }
    
    }
