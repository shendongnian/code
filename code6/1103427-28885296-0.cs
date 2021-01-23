       public class MyCutomModel
    {
      public int Id { get; set; }
      public string Name { get; set; }
    }
    public class HomeController : Controller
    
      //
      // GET: /Home/
      public ActionResult Index(int page = 1)
      {
         List<MyCutomModel> model = new List<MyCutomModel>();
         for (int i = 0; i < 10; i++)
         {
            model.Add(new MyCutomModel { Id = i, Name = "Name " + i.ToString() });
         }
         if (Request.IsAjaxRequest())
         {
            return PartialView("_Index", model.ToPagedList(page, 4));
         }
         return View(model.ToPagedList(page, 4));
      }
    }
