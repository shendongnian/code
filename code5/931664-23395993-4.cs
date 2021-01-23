	[HttpPost]
    public ActionResult Update(RepresentativeViewModel model)
	{
		using (var context = new MyContext())
		{
			var entity = context.reps.Find(rep.RepID);
			
			entity.FirstName = model.FirstName;
			entity.LastName = model.LastName;			
			
			context.SaveChanges();
		}
		
		return RTA(...);
	}
