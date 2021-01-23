    session.QueryOver<Child>()
        .Where(Restrictions.Eq(
            Projections.SqlProjection(
                "{alias}.Parent_id as ParentId",
                new[] { "ParentId" },
                new[] { NHibernateUtil.Int32 }), 1))
        .List<Child>();
