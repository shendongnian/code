    //This method will be called for every change you do - performance may be a concern
    public override int SaveChanges()
    {
    	//Every entity that has a particular property
    	foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("YourDateField") != null))
    	{
    		if (entry.State == EntityState.Added)
    		{
    			var date = entry.Property("YourDateField");
    			//I guess that if it's 0001-01-01 00:00:00, you want it to be DateTime.Now, right?
    			//Of course you may want to verify if the value really is a DateTime - but for the sake of brevity, I wont.
    			if (date.CurrentValue == default(DateTime))
    			{
    				date.CurrentValue = DateTime.Now;
    			}	
    			else //else what? 
    			{
    				//Well, you don't really want to change this. It's the value you have set. But i'll leave it so you can see that the possibilities are infinite!
    			}
    		}
    		if (entry.State == EntryState.Modified)
    		{
    			//If it's modified, maybe you want to do the same thing.
    			//It's up to you, I would verify if the field has been set (with the default value cheking)
    			//and if it hasn't been set, I would add this:
    			date.IsModified = false;
    			//So EF would ignore it on the update SQL statement.
    		}
    	}
    }
