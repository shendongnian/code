    	private static Expression AddNotNullExpression(MemberExpression field, Expression expression)
		{
			if(field.Type.IsNullable())
			{
				// String mag niet null zijn
				Expression nullConstant = Expression.Constant(null, field.Type);
				Expression notNull = Expression.NotEqual(field, nullConstant);
				expression = Expression.AndAlso(notNull, expression);
			}
			return expression;
		}
