      public class AnotherModel
      {
         public InnerModel InnerProp1 { get; set; }
         public InnerModel InnerProp2 { get; set; }
      }
      public class InnerModel
      {
         public string Input { get; set; }
      }
      public class EditorExampleController : Controller
      {
         //
         // GET: /EditorExample/
         public ActionResult Index()
         {
            AnotherModel model = new AnotherModel();
            model.InnerProp1 = new InnerModel { Input = "test 1" };
            model.InnerProp2 = new InnerModel { Input = "test 2" };
            return View(model);
         }
      }
