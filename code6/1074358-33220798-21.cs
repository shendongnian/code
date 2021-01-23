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
            // the value is received in the controller.
            var selectedGender = model.Gender;
            return View(model);
        }
    }
