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
						   Value = value
		               };
		var convertedFunc = replacer.Visit(func) as Expression<Func<TSource, DropDownListItem>>;
		return query.Select(convertedFunc);
	}
	private class ExpressionReplacer<TSource> : ExpressionVisitor
	{
		public Expression<Func<TSource, long>> Value { get; set; }
		public Expression<Func<TSource, string>> Text { get; set; }
		protected override Expression VisitConstant(ConstantExpression node)
		{
			if (node.Type == typeof(long))
				return Value.Body;
			if (node.Type == typeof(string)) 
				return Text.Body;
			return base.VisitConstant(node);
		}
	}
	ToDropDownList<RubricEntity>(_service.RubricAsQueryable(), x => x.Key, x => x.Value);
