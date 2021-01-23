	[HttpPost]
    public ActionResult Update(rep model)
	{
		using (var context = new MyContext())
		{
			var entity = context.reps.Find(rep.repid);
			
			entity.FirstName = model.FirstName;
			entity.LastName = model.LastName;			
			
			context.SaveChanges();
		}
		
		return RTA(...);
	}
