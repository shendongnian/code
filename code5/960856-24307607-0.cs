    public class DirectoryController : Controller {
        [HttpPost()]
        public ActionResult Index(string userName) { // make the input argument match your form field name.
            //TODO: Your search code here.
            return PartialView("SearchResults"); // Assuming you have a partial view for displaying results.
        }
    }
