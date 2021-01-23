    session.QueryOver<PersonEntity>()
        .Select(
            Projections.Max(
                Projections.SqlFunction(
                    new SQLFunctionTemplate(
                        NHibernateUtil.String,
                        "split_part(?1, ?2, ?3)"),
                    NHibernateUtil.String,
                    Projections.Property<PersonEntity>(p => p.Name),
                    Projections.Constant("-"),
                    Projections.Constant(2))))
        .SingleOrDefault<int>();
