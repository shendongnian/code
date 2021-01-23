    [RoutePrefix("reviews")]
    public class ReviewsController : Controller
    {
        // The route name is defaulted to "Reviews.Index" 
        [Route]
        public ActionResult Index() { ... }
        // The route name is "ShowReviewById"
        [Route("{reviewId}"), RouteName("ShowReviewById")]
        public ActionResult Show(int reviewId) { ... }
