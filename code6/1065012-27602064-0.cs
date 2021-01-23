    public class GeneralController : Controller
    {
        public ActionResult Index()
        {
            // Everyone can come here
        }
    }
    [Authorize(Roles = "Billing")]
    public class BillingController : Controller
    {
        public ActionResult Index()
        {
            // Only those with the 'billing' role can come here
        }
    }
