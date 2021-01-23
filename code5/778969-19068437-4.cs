    var query = 
     from u in _db.USERS_TABLE
     select new {
         User = u,
         CurrentActivities = u.ActivityHistory
                              .Include("Activity")
                              .Where(y => 
                                     y.DateFrom <= DateTime.Now
                                  && y.DateTo >= DateTime.Now)
     }
