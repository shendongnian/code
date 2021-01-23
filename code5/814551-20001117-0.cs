	public abstract class GenericController<T> 
		where T : class
	{
		public virtual ActionResult Details(int id)
		{
			var model = _repository.Set<T>().Find(e => e.ID == id);
			return View(model);
		}
	}
	
