    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
        public FileResult Getfile(string downloadFileName)
        {
            byte[] fl = System.IO.File.ReadAllBytes(@"C:\temp\sampleFile.pdf");
            string fileName = "Somefile.pdf";
            return File(fl, System.Net.Mime.MediaTypeNames.Application.Octet);
        }
    }
