    public class RedirectController : Controller
    {
        public ActionResult ProjectPageContent(Int32 id)
        {
            return RedirectPermanent(String.Format("/Project/Page/{0}/Content", id));
        }
    }
