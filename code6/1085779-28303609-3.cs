    using (var db = new MyEFContext())
    {
       // Execute queries here
       var query = from u as db.User
                   where u.UserId = 1234
                   select u.Name;
       // Execute the query.
       return query.ToList();
       // This bracket will dispose the context properly.
    }
