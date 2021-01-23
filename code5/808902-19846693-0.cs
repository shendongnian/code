    public class MyController : Controller
    {
        public ActionResult SomeView(bool myBool)
        {
            if (myBool)
            {
                ModelState.AddModelError("message", "This is true");
                return View();
            }
            
            return RedirectToAction("SomeOtherView");
        }
    }
