    namespace MvcApplication4.Controllers
    {
        public class HomeController : Controller
        {
    
            public ActionResult Index()
            {
                return new ViewResult();
            }
    
            public ActionResult Media(int id)
            {
                string fn = Server.MapPath("~/App_Data/boxed-delete.avi");
                var memoryStream = new MemoryStream(System.IO.File.ReadAllBytes(fn));
                return new FileStreamResult(memoryStream, MimeMapping.GetMimeMapping(System.IO.Path.GetFileName(fn)));
            }
    
        }
    }
