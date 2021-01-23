	ParameterExpression p = Expression.Parameter(domainObject.GetType());
	Expression property = Expression.Property(p, "ID");
	Expression c = Expression.Constant(id);
	Expression body = Expression.Equal(property, c);
	Expression exp = Expression.Lambda(body, new ParameterExpression []{ p });
	MethodInfo singleMethod = typeof(Queryable).GetMethods().Single(m => m.Name == "Single" && m.GetParameters().Count() == 2).MakeGenericMethod(domainObject.GetType());
				
	DbSet dbSet = context.Set(domainObject.GetType());
	object entity = singleMethod.Invoke(null, new object[]{ dbSet, exp });
