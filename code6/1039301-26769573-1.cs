    CurrentSession.CreateCriteria<Employee>("employee")
		.Add(Expression.Sql(
			"Exists (select top 1 null from contact.sfEmployeeDefaultLMSOwnershipCapacities dc where dc.EmployeeId = {alias}.Id and dc.Capacity = ?)", 
			"'" + OwnershipCapacity.VehicleFinance + "'", 
			NHibernateUtil.String))
		.SetProjection(Projections.Id())
		.List<Guid>();
