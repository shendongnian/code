	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			var service = new ApplicationServices.SomeService();
			service.DoSmth();
			return View();
		}
	}
