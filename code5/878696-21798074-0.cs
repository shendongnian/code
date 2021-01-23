    public class PrivateMessageController : Controller
    {
        private PrivateMessageContext db = new PrivateMessageContext();
        // GET: /PrivateMessage/
        public ActionResult Index()
        {
            var privatemessagedetail = db.PrivateMessageDetail.FirstOrDefault < PrivateMessageDetail>();
            return View();
        }
    }
