    
    public static class MvcHtmlHelpers
    {
       public static MvcHtmlString ShortNameFor<TModel, TValue>(this HtmlHelper<TModel> self, 
               Expression<Func<TModel, TValue>> expression)
       {
           var metadata = ModelMetadata.FromLambdaExpression(expression, self.ViewData);
           var name = metadata.ShortDisplayName ?? metadata.DisplayName ?? metadata.PropertyName;
    
           return MvcHtmlString.Create(string.Format(@"<span>{0}</span>", name));
       }
    }
