    string location = "Columbus OH";
    
    var session = NHSession.GetCurrent();
    var query = session.CreateCriteria<Request>();
    query.Add(Restrictions
        .Eq( // SQL Server function call
            Projections.SqlProjection(
                "Replace(LocationName,',','') as Replacement"
                , new[] {"Replacement"}
                , new IType[] {NHibernateUtil.String})
            , location // searched value
        ));
    var list = query.List<Request>();
