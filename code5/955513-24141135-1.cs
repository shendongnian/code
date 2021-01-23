    Func<Pantient, bool> predicate = p => false;
    
    if (User.IsInRole("Administrator"))
    {
    	var oldPredicate = predicate;
    	predicate = p => oldPredicate(p) || p.AdministratorID == UserID;
    }
    
    if (User.IsInRole("Counselor"))
    {
    	var oldPredicate = predicate;
    	predicate = p => oldPredicate(p) || p.CounselorID == UserID;
    }
    
    
    var query = db.Patients.Where(predicate);
