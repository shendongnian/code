    public void Update(Jobwalker detachedEntity)
	{
		DB.Jobwalkers.Attach(detachedEntity);
		DB.Entry(detachedEntity).State = EntityState.Modified;
	}
    // in your code to save Jobwalker detached object do this:
    Update(this); // `this` is the Jobwalker detached object
    DB.SaveChanges();
