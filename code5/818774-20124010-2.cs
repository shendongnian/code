    var query = NHibernateHelper.OpenSession().CreateCriteria<Test>();
       query.CreateAlias("Categories", "cat1", NHibernate.SqlCommand.JoinType.InnerJoin);
       query.CreateAlias("Categories", "cat2", NHibernate.SqlCommand.JoinType.InnerJoin);
       query.Add(Restrictions.In("cat1.CategoryID", new List<int> { 1, 2, 3}));
       query.Add(Restrictions.In("cat2.CategoryID", new List<int> { 5 }));
