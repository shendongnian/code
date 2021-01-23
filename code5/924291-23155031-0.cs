    public static class CustomHelper
    {
     public static MvcHtmlString YourCustomHelper<TModel, TValue> (
        this HtmlHelper<TModel> htmlHelper, 
        Expression<Func<TModel, TValue>> expression ---- )
        {
            //Write your custom logic here.
        }
    }
