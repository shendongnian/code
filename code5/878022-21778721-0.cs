     public class DefaultController : Controller
    {
       Public ActionResult Index()
       {
          Model model = new Model();
          model.TechId = "TechId here";
          model.TechName = "TechName";
          return View(model);
       }
       
        public ActionResult InterView()
         {
             return View();
         }
        [HttpPost]
        public ActionResult InterView(int techId, string techName)
        {
           //retrive model here 
           //return your interview view here
           return View("InterView");
        }
    }
