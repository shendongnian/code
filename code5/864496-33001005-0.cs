    public System.Data.DataTable GetLinkedUsers(int parentUserId, bool useDbFunctions = true)
    {
        var today = DateTime.Now.Date;
        var queryable = from up in DB.par_UserPlacement
                    where up.MentorId == mentorUserId;
        if (useDbFunctions) // use the DbFunctions
        {
         queryable = queryable.Where(up => 
         DbFunctions.TruncateTime(today) >= DbFunctions.TruncateTime(up.StartDate)
         && DbFunctions.TruncateTime(today) <= DbFunctions.TruncateTime(up.EndDate));
        }  
        else
        {
          // do db-functions equivalent here using C# logic
          // this is what the unit test path will invoke
          queryable = queryable.Where(up => up.StartDate < today);
        }                    
        var query = from up in queryable
                    select new
                    {
                        up.UserPlacementId,
                        up.Users.UserId,
                        up.Users.FirstName,
                        up.Users.LastName,
                        up.Placements.PlacementId,
                        up.Placements.PlacementName,
                        up.StartDate,
                        up.EndDate,
                    };
        query = query.OrderBy(up => up.EndDate);
        return this.RunQueryToDataTable(query);
    }
