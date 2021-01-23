    using System.Web.Mvc;
    
    namespace MvcPlayground.Controllers
    {
        public class StackController : Controller
        {
            //
            // GET: /Stack/
    
            public ActionResult Index()
            {
                return View();
            }
    
            public ActionResult Create(FormCollection form)
            {
                string htmlStr = form["content"].ToString();
    
                return View("Index");
            }
        }
    }
