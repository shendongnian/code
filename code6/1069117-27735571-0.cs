	public static class HtmlExtensions
	{
		public static string Foo<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> ex)
		{
			return ExpressionHelper.GetExpressionText(ex);
		}
	}
