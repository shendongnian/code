    public class BaseController : System.Web.Mvc.Controller
    {
        public ViewResult UIViewResult(dynamic model)
        {
          ViewBag = model;
          return base.View();
        }
    }
