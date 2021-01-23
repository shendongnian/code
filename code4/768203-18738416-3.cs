    DetachedCriteria dc = DetachedCriteria.For(typeof(Order), "order2")
        .CreateAlias("Customer", "customer2", JoinType.InnerJoin)
        .Add(Restrictions.EqProperty("customer2.ID", "customer1.ID"))
        .AddOrder(NHibernate.Criterion.Order.Desc("order2.OrderDate"))
        .SetProjection(Projections.Property("order2.ID"))
        .SetMaxResults(1);
    ICriterion condition = Subqueries.Exists(dc);
    ICriteria criteria = Session.CreateCriteria(typeof(Order), "order1")
        .CreateAlias("Customer", "customer1", JoinType.InnerJoin)
        .Add(condition);
