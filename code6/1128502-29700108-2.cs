	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			var listOfFiles = new DocumentsController().GetAllRecords();
			// OR
			var listOfFiles = new FileListGetter().GetAllRecords();
			
			return View(listOfFiles);
		}
	}
