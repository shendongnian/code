    public interface IWhatever
    {
        Task GetStuff();
    }
    public class Whatever : IWhatever
    {
        private readonly IReportingBL reportingBL;
    
        public whatever(IReportingBL reportingBL) {
            this.reportingBL = reportingBL;
        }
        public Task GetStuff() {
            return _taskFactory.StartNew(() => {
                return ReportingBL.Method1;
            });
        }
    }
    // Some consumer of whatever
    public class MyController : Controller
    {
        private readonly IWhatever whatever;
        public MyController(IWhatever whatever) {
            this.whatever = whatever;
        }
        public ActionResult Index() {
            return View(this.whatever.GetStuff());
        }
    }
