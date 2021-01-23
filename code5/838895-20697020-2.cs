    var list = session  // here we have Contact query
        .QueryOver<Contact>()
           .Where(... //filter contact
        // Join Parnter
        .JoinQueryOver<Employee>(c => c.Parnter)
            .Where(... //filter Partner
        // Join More
        .JoinQueryOver<Employee>(e => e.Creator)
 
        // While still having the Root in the scope we can do
        .SelectList(list => list....
        .OrderBy(c => c.ID)
          .Desc
        .ThenBy(c => c.Code)
          .Asc
        .Take(50)
        .Skip(50)
        .List<Contact>(); // the Root
    
