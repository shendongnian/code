        public class ServiceController : Controller    {
    
        public ActionResult ServiceRequest()
        {
            return View();
        }
    
        [HttpPost]
        public ActionResult ServiceRequest(RequestViewModel rvm, HttpPostedFileBase image = null, HttpPostedFileBase video = null)
        {
            throw new NotImplementedException();
        }}
