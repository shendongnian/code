	public static IQueryable<DropDownListItem> ToDropDownList<TSource>(IQueryable<TSource> query, Expression<Func<TSource, long>> value, Expression<Func<TSource, string>> text)
	{
		Expression<Func<TSource, DropDownListItem>> func = x => new DropDownListItem
		{
			Value = 1,
			Text = "1"
		};
		var replacer = new ExpressionReplacer<TSource>()
		               {
			               Text = text,
						   Value = value,
						   Parameter = func.Parameters[0] // we will take X parameter
		               };
		var convertedFunc = replacer.Visit(func) as Expression<Func<TSource, DropDownListItem>>;
		return query.Select(convertedFunc);
	}
	private class ExpressionReplacer<TSource> : ExpressionVisitor
	{
		public Expression<Func<TSource, long>> Value { get; set; }
		public Expression<Func<TSource, string>> Text { get; set; }
		public ParameterExpression Parameter { get; set; }
		protected override Expression VisitConstant(ConstantExpression node)
		{
			if (node.Type == typeof(long))
				return this.Visit(Value.Body);
			if (node.Type == typeof(string)) 
				return this.Visit(Text.Body);
			return base.VisitConstant(node);
		}
		protected override Expression VisitParameter(ParameterExpression node)
		{
			// we will replace all usage to X. it has the same type, but it isn't linked to expiression
			return Parameter; 
		}
	}
	ToDropDownList<RubricEntity>(_service.RubricAsQueryable(), x => x.Key, x => x.Value);
