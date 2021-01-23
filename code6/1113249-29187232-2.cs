    using Microsoft.AspNet.Identity;
        
    namespace Whey.Controllers
    {
        public class MyWheyController : Controller
        {
            public ActionResult Index()
            {
                WheyPageModel wheyModel = PopulateWheyPageModel.PopulateWheyPage(User.Identity.GetUserId()); // <-- This Fella
    
                return View(wheyModel);        
            }
        }
    }
