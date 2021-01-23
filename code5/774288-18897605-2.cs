    var sample =
        (
            from e in dataContext.tblA.Include("tblB")
            where e.Active == true && System.Data.Objects.EntityFunctions.CreateDateTime(e.DateA.Year, e.DateA.Month,e.DateA.Day,e.DateB.Hour,e.DateB.Minute,e.DateB.Second) >= DateTime.Now
            select new 
                   {
                   ...
                   }
        ).ToList();
