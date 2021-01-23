    foreach(var sponser in model.Sponsors)
    {
          if(sponser.ID <= 0)
          {
             db.Sponsors.Add(sponser);
          }
          else if(db.Entry(sponser).State == EntityState.Detached)
          {
             db.Sponsors.Attach(sponser);
             db.Entry(sponser).State = EntityState.Modified;
          }
          
    }
    db.SaveChanges();  
