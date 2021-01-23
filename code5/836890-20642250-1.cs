    public class CommentController : Controller
    {
        public ActionResult Index()
        {
            var model = new CommentViewModel()
            {
                CommentModels = listComments
            };
            return View(model);
        }
        public PartialViewResult _GetForSession(string isbnNo)
        {
            ViewBag.ISBN_No = isbnNo;
            var model = new CommentViewModel
            {
                CommentModels = CommentFacade.GetAllCommentsOnIsbn(isbnNo);
            };
            return PartialView("_GetForSession", model);
        }
        [ChildActionOnly]
        public PartialViewResult _CommentForm(string isbnNo)
        {
            var model = new CommentViewModel()
            {
                CommentModel = new CommentModel() {ISBN_No = isbnNo}
            };
            return PartialView("_CommentForm", model);
        }
        [ValidateAntiForgeryToken]
        public PartialViewResult _Submit(CommentViewModel model)
        {
            CommentFacade.SaveComment(comment);
            List<CommentModel> comments = CommentFacade.GetAllCommentsOnIsbn(comment.ISBN_No);
            ViewBag.ISBN_No = comment.ISBN_No;
            return PartialView("_GetForSession", model);
        }
    }
