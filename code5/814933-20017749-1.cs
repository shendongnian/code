	public abstract class GenericController<T> : Controller
		where T : class
	{
		protected YourEFContext _dataSource;
		public GenericController()
		{
			_dataSource = new YourEFContext();
		}
		public virtual ActionResult Details(int id)
		{
			var model = _dataSource.Set<T>().Find(id);
			return View(model);
		}
	}
	public class CustomerController : GenericController<Customer>
	{
	
	}
