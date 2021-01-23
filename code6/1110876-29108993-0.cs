    session.QueryOver<Person>()
        .Select(Projections.SqlFunction(
            "concat",
            NHibernateUtil.String,
            Projections.Property<Person>(p => p.LastName),
            Projections.Constant(", "),
            Projections.Property<Person>(p => p.FirstName)))
        .List<string>();
