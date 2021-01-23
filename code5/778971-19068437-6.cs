    var query = 
     from u in _db.USERS_TABLE
     select new {
         User = u,
         CurrentActivities = u.ActivityHistory
                              .Where(y => 
                                     y.DateFrom <= DateTime.Now
                                  && y.DateTo >= DateTime.Now)
                              .Select(ah => new 
                              {
                                ActivityHistory = ah,
                                Activity = ah.Activity
                              }
     }
