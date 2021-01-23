	public class HomeController : Controller
	{
		public ActionResult HomeAction() { ... }
	}
	public class AnotherController : Controller
	{
		public ActionResult AnotherAction() { ... }
		private void Process()
		{
			Url.Action(nameof(AnotherAction), nameof(HomeController));
		}
	}
