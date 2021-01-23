	public class MyController : Controller
	{
		public MyController(IMyRepository repository)
		{
			if (repository == null)
				throw new ArgumentNullException("repository");
			this.repository = repository;
		}
		private readonly IMyRepository repository;
		public ActionResult Index()
		{
			var items = this.repository.GetList()
			return View(items);
		}
	}
