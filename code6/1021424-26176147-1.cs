    [RoutePrefix("Book-Reviews")]
    public class ReviewsController : Controller
    {
        // eg.: /reviews
        [Route]
        public ActionResult Index() { ... }
        // eg.: /reviews/5
        [Route("{reviewId}")]
        public ActionResult Show(int reviewId) { ... }
        // eg.: /reviews/5/edit
        [Route("{reviewId}/edit")]
        public ActionResult Edit(int reviewId) { ... }
    }
