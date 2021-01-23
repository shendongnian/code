	public abstract class GenericController<T> 
		where T : class
	{
		public virtual ActionResult Details(int id)
		{
			var model = _repository.Set<T>().Find(id);
			return View(model);
		}
	}
	
