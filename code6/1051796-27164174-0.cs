    public class FirstController : Controller
    {
      public ActionResult Index()
      {
        return PartialView();
      }
    }
    public class SecondController : Controller
    {
      [ChildActionOnly]
      public ActionResult Method1()
      {
        return PartialView();
      }
    }
    public class ThirdController : Controller
    {
      [ChildActionOnly]
      public ActionResult Method2(int ID)
      {
        return PartialView();
      }
    }
