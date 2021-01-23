	[QueryFilter]
	public class ConferenceController : Controller
	{
		public ActionResult Index(IndexQuery query)
		{
			return View();
		}
		public ViewResult Show(ShowQuery query)
		{
			return View();
		}
		public ActionResult Edit(EditQuery query)
		{
			return View();
		}
	}
