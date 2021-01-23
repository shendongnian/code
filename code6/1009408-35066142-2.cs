    public class OrderController : Controller
    {
        public ActionResult Create()
        {
            var model = new MyModel();
            model.Test= "xyz";
            return View("MyView", model);
        }
    }
