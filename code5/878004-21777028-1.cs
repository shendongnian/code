    Expression<Func<Customer, bool>> filter = c => c.Active;
 	Expression<Func<Customer, bool>> filterz = c => c.Visible;
		
	var newParameter = Expression.Parameter(typeof(Customer), "x");
	var visitor1 = new ReplacementVisitor(filter.Parameters[0], newParameter);
	var visitor2 = new ReplacementVisitor(filterz.Parameters[0], newParameter);
	
	var newLambda = Expression.Lambda(
		Expression.AndAlso(
			visitor1.Visit(filter.Body),
			visitor2.Visit(filterz.Body)
		),
		newParameter
	);
		
