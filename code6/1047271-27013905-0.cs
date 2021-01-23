    RecurringJob.AddOrUpdate(
    () => 
    {
    	using (UserZipDBContext db = new UserZipDBContext())
    	{
    	    //delete old files
    	    DateTime timePoint = DateTime.Now.AddHours(-24);
    	    foreach (UserZip file in db.UserFiles.Where(f => f.UploadTime < timePoint))
    	    {
    		db.UserFiles.Remove(file);
    	    }
    	    db.SaveChanges();
    	}    
    }
    Cron.Hourly);
