    public class Auth : Controller
    {
        /* snip */
        
        [ChildActionOnly]
        public ActionResult Login()
        {
            return View(/* model? */);
        }
    }
