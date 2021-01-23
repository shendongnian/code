    var ci = db.Incidents
        .Where(a => a.FollowUpDate.Value.Year == DateTime.Now.Year
                   && a.FollowUpDate.Value.Month == DateTime.Now.Month)
        .Select(r=> new MyClass
              { 
                Property1 = r.Property1,
               //rest of the properties .....
             }).ToList();
