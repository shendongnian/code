    var criterion = NHibernate.Criterion.Expression
        .Sql("({alias}.Id IN (SELECT Id FROM dbo.fGetSomeIds(?, ?))"
            + " AS MyCriteria",
            new object[] { "param1", "param2" },
            new IType[] { NHibernateUtil.String, NHibernateUtil.String });
    // query.Where(sqlCriterion);
    query.Where(criterion);
