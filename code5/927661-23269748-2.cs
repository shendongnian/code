    public class DownloadController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    
        public ActionResult DownloadFile(DownloadModel model)
        {
            // read form value via model
            System.Diagnostics.Debug.WriteLine(model.InputA);
            System.Diagnostics.Debug.WriteLine(model.InputB);
            
            // assume we create an an excel stream...
            MemoryStream excelStream = new MemoryStream();
    
            return new FileStreamResult(excelStream, "application/vnd.ms-excel")
            {
                FileDownloadName = "myfile.xslx"
            };
        }
    }
