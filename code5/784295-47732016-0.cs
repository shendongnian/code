	public class StoryController : BaseController
	{
		[OutputCache(Duration=CacheDuration.Days1)]
		// /story/(id)
		public async Task<ActionResult> Id(string id = null)
		{
			string storyFilename = id;
			// Get the View - story file
			if (storyFilename == null || storyFilename.Contains('.'))
				return Redirect("/");	// Disallow ../ for example
			string path = App.O.AppRoot + App.HomeViews + @"story\" + storyFilename + ".cshtml";
			if (!System.IO.File.Exists(path))
				return Redirect("/");
			return View(storyFilename);
