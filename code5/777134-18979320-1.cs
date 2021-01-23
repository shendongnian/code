    public class MyController : Controller
    {
        public ActionResult Full(Filters filters = null)
        {
            if (filters == null)
            {
                //nothing passed in
            }
            else
            {
                //do some work
            }
            return View();
        }
     }
