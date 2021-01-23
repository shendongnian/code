    class ActionController : Controller
    {
        // ...
        public ActionResult AnotherAction()
        {
            // Do stuff here
            return LogOff(); // You don't have to return the results if they're not needed
        }
        // ...
    }
