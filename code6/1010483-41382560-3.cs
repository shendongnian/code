    public class HomeController : Controller
        {
            public ActionResult Index()
            {
                AmazonS3Uploader amazonS3 = new AmazonS3Uploader();
    
                amazonS3.UploadFile();
                return View();
            }
        ....
