    public class MyController {
        //this is your existing action
        public ActionResult Index() {
            //Your current session code
            return View("Index");
        }
        
        public ActionResult ChangeVariable(int thresholdSelect) {
            Session["selected"] = thresholdSelect;
            ViewBag["Message"] = "Your selection was changed.";
            return Index();
        }
    }
