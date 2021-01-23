	public class FooController : Controller
	{
		public ActionResult Index()
		{
			using(var database = new DatabaseContext())
			{
				var query = from x in database.Foos
							...blah blah blah...
							select x;
				return View(query.ToList());
			}
		}
	}
