    public class MyController : Controller
    {
        public ActionResult someView(bool myBool)
        {
            if (myBool)
            {
                return View();
            }
            return RedirectToAction("actionname");
        }
    }
