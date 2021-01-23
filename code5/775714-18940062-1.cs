    class ForumController : Controller
    {
        public ActionResult Detail(int id)
        {
            Forum model = LoadForumById(id);
            return View(model); // Forum has an "Id" property
        }
    }
