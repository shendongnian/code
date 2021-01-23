    // this is a subquery (SELECT ....
    System syst = null;
    Installation installation = null;
    var subquery = QueryOver.Of(() => syst)
        .JoinQueryOver(x => x.Installation, () => installation)
        .Where(() => syst.Type == 1)
        .Select(x => installation.Solution.ID)
    ;
    // main Query 
    var query = session.QueryOver<Solution>()    
        .WithSubquery
            .WhereProperty(root => root.ID)
        .In(subquery)
        ;
    var list = query
       .Take(10)
       .Skip(10)
       .List<Solution>();
