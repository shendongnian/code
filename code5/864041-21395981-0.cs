    public class BaseController : Controller {
        public BaseController() {
            SetupDebugData();
        }
        [Conditional("DEBUG")]
        public void SetupDebugData() {
            Session["User"] = "1";
        }
    }
