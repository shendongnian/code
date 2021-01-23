    Func<Pantient, bool> predicate = p => false;
    
    if (User.IsInRole("Administrator"))
    {
    	var oldPredicate = predicate;
    	predicate = p => oldPredicate(p) || x.AdministratorID == UserID;
    }
    
    if (User.IsInRole("Counselor"))
    {
    	var oldPredicate = predicate;
    	predicate = p => oldPredicate(p) || x.CounselorID == UserID;
    }
    
    
    var query = db.Patients.Where(predicate);
