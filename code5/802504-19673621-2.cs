	public class FooController : Controller
	{
		private DatabaseContext _database = new DatabaseContext();
	
		public ActionResult Index()
		{
			var query = from x in database.Foos
						...blah blah blah...
						select x;
			return View(query);			
		}
		
		public override Dispose()
		{
			_database.Dispose();
		}
	}
