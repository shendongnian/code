    var predicate = PredicateBuilder.New<Patients>(true);
    
    if (User.IsInRole("Administrator"))
    {
         predicate = predicate.Or(x => x.AdministratorID == UserID);
    }
    if (User.IsInRole("Counselor"))
    {
         predicate  = predicate.Or(x => x.CounselorID == UserID);
    }
    if (User.IsInRole("Physician"))
    {
         predicate  = predicate.Or(x => x.PhysicianID == UserID);
    }
    query = query.Where(predicate)
               
