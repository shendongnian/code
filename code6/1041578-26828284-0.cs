    if(!db.user.Where<user>(u => u.id == status.user.id).Any<user>())
    	db.user.Add(status.user);
    else
    {
    	//db.user.Attach(status.user);
    	db.Entry(status.user).State = EntityState.Modified;
    }
    	db.status.Add(status);
    	db.SaveChanges();
