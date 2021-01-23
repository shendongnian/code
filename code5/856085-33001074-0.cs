    public SomeMethodWithDbFunctions(bool useDbFunctions = true)
    {
        var queryable = db.Employees.Where(e=>e.Id==1); // without the DbFunctions
        if (useDbFunctions) // use the DbFunctions
        {
         queryable = queryable.Where(e=> 
         DbFunctions.AddSeconds(e.LoginTime, 3600) <= DateTime.Now);
        }  
        else
        {
          // do db-functions equivalent here using C# logic
          // this is what the unit test path will invoke
          queryable = queryable.Where(e=>e.LoginTime.AddSeconds(3600) < DateTime.Now);
        }                    
        var query = queryable.Select(); // do projections, sorting etc.
    }
