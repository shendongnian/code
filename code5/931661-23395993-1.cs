	[HttpPost]
    public ActionResult Update(rep model)
	{
		using (var context = new MyContext())
		{
			context.reps.Attach(model);
			context.SaveChanges();
		}
		
		return RTA(...);
	}
        
