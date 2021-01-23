    var list = new []{
    	new { PersonId = 1, Name = "Is", Lastname = "Shin", VisitName = "a" },
    	new { PersonId = 1, Name = "Is", Lastname = "Shin", VisitName = "b" },
    };
    
    (
    from i in list
    group i by i.PersonId into g
    let first = g.First()
    select new {
    	Person = new { ID = first.PersonId, Name = first.Name, Lastname = first.Lastname },
    	Visits = g.Select(gi => new { VisitName = gi.VisitName } )
    }
    ).Dump();
