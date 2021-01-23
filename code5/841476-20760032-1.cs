    public class Request_HandlerController : Controller
    {
        public ActionResult Quran_Loading()
        {
              List<thing> things = (List<thing>)TempData["Things"];
              // Do some code with things here
        }
    }
