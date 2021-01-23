    private static Expression GetStringCompareExpression<TEntity>(Expression parameters, string method, FilterContainer filter, Type type)
	{
		Expression expression;
		MemberExpression field = Expression.PropertyOrField(parameters, filter.field);
		Expression constant = Expression.Constant(filter.value.ToLower().Trim(), type);
		Expression lowercase = Expression.Call(field, "ToLower", null, null);
		Expression trim = Expression.Call(lowercase, "Trim", null, null);
		expression = AddNotNullExpression(field, Expression.Call(trim, method, null, constant));
		return expression;
	}
