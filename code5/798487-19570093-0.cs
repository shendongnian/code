    routes.MapRoute(
      "File_Fetch",
      "{filename}",
      new { controller = "File", action = "Fetch", filename = UrlParameter.Optional },
      new { filename = @"^.+$" }
    );
    public class FileController : Controller
    {
        public ActionResult Fetch(String filename)
        {
            // /Url -> filename = "Url"
            // /uRl -> filename = "uRl"
            return File(...);
        }
    }
