    public static MvcHtmlString CreateControl<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, IEnumerable<SelectListItem> items, object htmlAttributes = null) 
        where TModel : IMyModel
    {
        var myModel = (IMyModel)htmlHelper.ViewData.Model;
        //Now you can read the property:
        var value = myModel.MyValue;
    }
