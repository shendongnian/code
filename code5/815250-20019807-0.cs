    [HandleError]
    public class YourController: Controller
    {
        [HandleError] // or here
        public ActionResult YourAction()
        {
            // code
            return View();
        }
    }
