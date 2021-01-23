    var existingStatus = db.INV_Statuses.FirstOrDefault(s => s.status_description == description);
    
    if (existingStatus ==null)
    {
       db.INV_Statuses.Add(status);
       db.SaveChanges();
    }
    else 
    { 
       // set the status back to existing
       status = existingStatus;   
    }
