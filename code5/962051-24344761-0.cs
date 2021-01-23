    public static class HtmlHelperExtensions
    {
        public static IHtmlString DisplayColumnNameFor<TModel, TCollection, TProperty>(
            this HtmlHelper<TModel> helper,
            IEnumerable<TCollection> model,
            Expression<Func<TCollection, TProperty>> expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }
            var dictionary = new ViewDataDictionary<TCollection>();
            var metadata = ModelMetadata.FromLambdaExpression(expression, dictionary);
            return new MvcHtmlString(metadata.DisplayName);
        }
    }
