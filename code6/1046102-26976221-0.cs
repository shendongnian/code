     public class CuisineController : Controller
    {
        public ActionResult Search(string name)
       {
          return RedirectToRoute(**"Redirect", "Cuisine"**);
       }
       public ActionResult Redirect()
       {
          return Content("Restaurant Closed");
       }
    }
