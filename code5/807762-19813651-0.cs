    using LinqKit;
    
    var predicate = PredicateBuilder.False<User>();
    
    foreach(var amico in amiciParsed)
    {
        var a1 = amico; // Prevent modified closure (pre .Net 4.5)
        predicate = predicate.Or(user => user.Nome == a1.first_name 
                                      && user.Cognome == a1.last_name);
    }
    
    var query = db.User.Where(predicate.Expand())
                  .OrderBy(p => p.Nome)
                  ...
