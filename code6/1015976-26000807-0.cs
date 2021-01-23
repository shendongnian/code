        dash.UserActivities = db.Activities..Where(a => a.AssignedUserId == userId && a => !a.IsComplete).OrderBy(a => a.DueDateTime).Select( a => new {  
     		        Id = a.Id,
                    CustomerFirstName = a.Customer.FirstName,
                    CustomerLastName = a.Customer.LastName,
                    ActivityType = a.ActivityType.Name,
                    DueDateTime = a.DueDateTime
      }).Take(10).Select(
                a => new ActivityViewModel()
                {
                    Id = a.Id,
                    CustomerFirstName = a.CustomerFirstName,
                    CustomerLastName = a.CustomerLastName ,
                    ActivityType = a.ActivityType 
                    DueDateTime = a.DueDateTime,
                }
            ).ToList();
