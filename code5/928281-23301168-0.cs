	public ActionResult Edit(A a)
	{
		if(ModelState.IsValid)
		{
			_context.Entry(a).State = EntityState.Modified;
			_context.Entry(a.SomeProperty ).State = EntityState.Modified;
			_context.SaveChanges();
		}
	}
