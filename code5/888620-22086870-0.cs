    // here is the criteria of the "Entity1" and the join to the "Entity2"
    var criteria = session.CreateCriteria("Entity1", "table1");
    criteria.CreateAlias("Entity2", "table2");
    // here we drive the SELECT clause
    criteria.SetProjection(
        Projections.ProjectionList()
            .Add(Projections.Property("Model"))
            .Add(Projections.SqlFunction("COALESCE", NHibernateUtil.String
                , Projections.Property("table2.TranslatedDescription")
                , Projections.Property("table1.Description")
                ))
        );
    // just a list of object arrays
    var list = criteria.List<object[]>();
