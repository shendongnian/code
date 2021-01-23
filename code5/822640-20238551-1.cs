    from r in Resources
    group r by new { 
       r.PersonId, 
       r.PersonFirstName,
       r.PersonLastName
    } into g
    select new Client {
        ClientId = g.Key.PersonId,
        FirstName = g.Key.PersonFirstName,
        LastName = g.Key.PersonLastName,
        Visits = g.SelectMany(r => 
                     r.Visits.Select(v => new OtherVisit {
                         Name = r.VisitName,
                         StartBefore = v.StartBefore,
                         StartAfter = v.StartAfter
                     })).ToArray();
                  
    }
