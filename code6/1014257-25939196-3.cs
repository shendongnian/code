    public class OldForumsController : Controller
    {
        public ActionResult RedirectToNewURLs(string page, int? forumId, int? threadId)
        {
            if (page == "ForumList")
            {
                return RedirectToActionPermanent("Index", "Forums");
            }
            if (page == "Threads")
            {
                return RedirectToActionPermanent("Threads", "Forums", { id = forumId });
            }
            // etc
        }
    }
