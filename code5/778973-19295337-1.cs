    public List<User> GetAll()
    {
       using (Entities _db = new Entities())
       {
          _db.Configuration.LazyLoadingEnabled = false;
    
          var now = DateTime.Now;
    
          var currentActivities = _db.ActivityHistory 
                                    .Where(x => x.DateFrom <= now && x.DateTo >= now)
                                    .Include("TheActivity")
                                    .ToList();
    
          var Controlers = _db.User.ToList();
    
          return Controlers;
       }
    }
