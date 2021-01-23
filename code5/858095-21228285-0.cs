    public class MyController : Controller {
      public ActionResult Index() {
        return View(new MyModel());
      }
      [HttpPost]
      public ActionResult Save(MyModel model) {
        // The values of the model will now be updated from the view
      }
    }
