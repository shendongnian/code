	public static Expression<Func<T, TReturn>> Join<T, TReturn>(Func<Expression, Expression, BinaryExpression> joiner, IReadOnlyCollection<Expression<Func<T, TReturn>>> expressions)
	{
		if (!expressions.Any())
		{
			throw new ArgumentException("No expressions were provided");
		}
		var firstExpression = expressions.First();
		var otherExpressions = expressions.Skip(1);
		var firstParameter = firstExpression.Parameters.Single();
		var otherExpressionsWithParameterReplaced = otherExpressions.Select(e => ReplaceParameter(e.Body, e.Parameters.Single(), firstParameter));
		var bodies = new[] { firstExpression.Body }.Concat(otherExpressionsWithParameterReplaced);
		var joinedBodies = bodies.Aggregate(joiner);
		return Expression.Lambda<Func<T, TReturn>>(joinedBodies, firstParameter);
	}
