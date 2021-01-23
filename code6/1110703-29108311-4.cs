        var orderByProjection = 
            Projections.SqlFunction(
                "concat",
                NHibernateUtil.String,
                Projections.Property<Person>(p => p.LastName),
                Projections.Constant(", "),
                Projections.Property<Person>(p => p.FirstName));
        var people = session.QueryOver<Person>()
            .OrderBy(orderByProjection).Asc
            .List<Person>();
