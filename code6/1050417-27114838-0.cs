	public static IQueryable<DropDownListItem> ToDropDownList<TSource>(IQueryable<TSource> query, Expression<Func<TSource, DropDownListItem>> value)
	{
		return query.Select(value);
	}
	ToDropDownList<RubricEntity>(_service.RubricAsQueryable(), x => new DropDownListItem() { Value = x.Id, Text = x.DisplayName });
