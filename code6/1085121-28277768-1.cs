    public class MyController
    {
        public ActionResult MyAction()
        {
            var myModel = new MyModel();
            // Set properties
            ViewBag.ActualViewModel = myModel
            return View()
        }
    }
