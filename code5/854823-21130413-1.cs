    [Authorize]
	[RoutePrefix("settings")]
	[Route("{action=index}")]
	public class SettingsController : ZenController
    { 		
		[Route("{id:int}")]
		public ActionResult Index(int id)
        {
			
			return View(model);
        }
		
		[Route("GetSite/{sitename:alpha}")]
		public ActionResult GetSite(string sitename)
		{
			
			return RedirectToAction("Index");
		}
