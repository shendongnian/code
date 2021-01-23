    public class BController()
    {
        public ActionResult BControllerAction()
        {
             return RedirectToAction("CControllerAction", "CController", new { param = "some string" })
        }
    }
    public class CController()
    {
        public ActionResult CControllerAction(string param)
        {
             if(!String.IsNullOrEmpty(param))
             {
                //do smth
             }
        }
    }
