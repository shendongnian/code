    //Simpler query for clarity's sake
    var myAnonymousResult = ctx.AuthorizationChecks
                                    .Where(x => x.IsActive)
                                    .Select(x => new { Name = x.Name, IsActive = x.IsActive })
                                    .ToList();
    
    var myCastResult = myAnonymousResult.Select(x => new Check() { Name = x.Name, IsActive = x.IsActive }).ToList();
