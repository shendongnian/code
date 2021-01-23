    public class MyController : Controller
    {
        public ActionResult someView(bool myBool)
        {
            if (myBool)
            {
                return RedirectToAction("actionname");
            }
            return View();
        }
    }
