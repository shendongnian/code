    session.QueryOver<Child>()
        .Where(Restrictions.Eq(
            Projections.SqlProjection(
                "{alias}.ParentId as ParentId",
                new[] { "ParentId" },
                new[] { NHibernateUtil.Int32 }), 1))
        .List<Child>();
