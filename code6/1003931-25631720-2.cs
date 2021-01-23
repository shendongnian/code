	var subQuery = DetachedCriteria.For(typeof(Session))
		.SetProjection(Property.ForName("Id"))
		.Add(Restrictions.Eq("Server", server))
		.AddOrder(Order.Desc("Id"))
		.SetMaxResults(10);
		
	var query = DetachedCriteria.For(typeof(Session))
		.Add(Subqueries.PropertyIn("Id", subQuery))
		.Add(Restrictions.Eq("Status", 32768))
		.SetProjection(Projections.RowCount());
		
	var result = (int)query.GetExecutableCriteria(s)
		.UniqueResult();
