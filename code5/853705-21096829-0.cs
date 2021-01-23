    [RouteArea("management")]
    [RoutePrefix("assets/course")]
    public class AssetsCourseController : Controller
    {
        [Route("edit/{id}")]
        public ActionResult Edit(string id) { ... }
    }
