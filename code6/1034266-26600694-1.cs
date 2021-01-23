	public class MyController : Controller
	{
		public MyController()
		{
			this.repository = this.GetOrCreateRepository();
		}
		private readonly IMyRepository repository;
		private IMyRepository GetOrCreateRepository()
		{
			var key = "MyControllerRepository";
			var result = HttpContext.Items[key];
			if (result == null)
			{
				// If the expensive dependency wasn't already created for this request, do it now
				result = new MyRepository();
				// Save the instance in the request, so the next time this controller is created,
				// it doesn't have to instantiate it again.
				HttpContext.Items[key] = result;
			}
			return result;
		}
		
		public ActionResult Index()
		{
			var items = this.repository.GetList()
			return View(items);
		}
	}
