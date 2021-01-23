	public override int SaveChanges()
	{
		foreach (var entry in ChangeTracker.Entries<Advert>().Where(e=>e.Entity.Slots.Count()==0))
		{
			entry.State = EntityState.Deleted;
		}
		return base.SaveChanges();
	}
