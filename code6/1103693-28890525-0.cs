    public static class HtmlHelperExtensions
    {
        public static IHtmlString AlternateTemplates<TModel>(this HtmlHelper htmlHelper, TModel model,
            Func<TModel, string> stringProperty, Func<string, HelperResult> template,
            Func<object, HelperResult> nullTemplate) where TModel : class
        {
            HelperResult result;
            
            if (model != null)
            {
                var propertyValue = stringProperty.Invoke(model);
                var splitValue = YourCustomSplitFunction(propertyValue); // TODO: Impliment yout split function to return a string (in this case)
                result = template(splitValue);
            }
            else
            {
                result = nullTemplate(null);
            }
            htmlHelper.ViewContext.Writer.Write(result);
            return MvcHtmlString.Empty;
        }
    }
