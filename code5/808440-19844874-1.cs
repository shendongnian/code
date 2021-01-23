    public class Controller
    {
        public ActionResult YourMethod()
        {
           // here you can set whatever message you want to display after the operation
            ViewData["Message"] = your message;
            return View(Model);
        }
    }
