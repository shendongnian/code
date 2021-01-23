    public class MyController : Controller 
    {
        public ActionResult MyAction()
        {
            // shows your form when you load the page
            return View();
        }
        [HttpPost]
        public ActionResult MyAction(MyModel model)
        {
            // Form is submitted, values are in the model.
            return View();
        }
    }
