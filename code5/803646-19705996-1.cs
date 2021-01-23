    public class PrintToPdfController : PdfGeneratorController
    {
        public ActionResult Index()
        {
            return ViewPdf(GetModel(userName));
        }
    }
