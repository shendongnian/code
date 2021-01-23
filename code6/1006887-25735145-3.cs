     public class HomeController : Controller
     {
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            var client = new Service1Client();          
            var buffer = new byte[file.ContentLength];
            file.InputStream.Read(buffer, 0, file.ContentLength);
            client.SaveFile(buffer, file.FileName);
           
            return View();
        }
    }
