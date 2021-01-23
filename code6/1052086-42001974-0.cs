    var IdsList = new List { /* Some Ids */ };
    var results = session.Query<A>()
                         .Fetch(a => a.B_ObjectsList)
                         .Where(a => IdsList.Contains(a.Id))
                         .ToList();
    
    // initialize C_ObjectsList
    var aQuery = session.Query<A>()
                        .Where(x => IdsList.Contains(x.Id));
    session.Query<B>()
           .Fetch(b => b.C_ObjectsList)
           .Where(b => aQuery.Contains(b.A)
           .Prefetch();
