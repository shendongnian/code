    public class ReportGeneratorController : Controller
    {
        [HttpGet]
        public ActionResult ProjectReport()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ProjectReport(ReportParamModel model)
        {
            return View(model);
        }
    }
