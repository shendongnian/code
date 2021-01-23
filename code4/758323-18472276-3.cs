    namespace System.Web.Mvc.Html
    {
        public static class CustomHelpers
        {
            public static MvcHtmlString MyHelperFor<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression)
            {
                var metaData = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
                var name = metaData.PropertyName;
                // create your html string, you could defer to DisplayFor to render a span or
                // use the TagBuilder class to create a span and add your attributes to it
                string html = "";
                return new MvcHtmlString(html);
            }
        }
    }
