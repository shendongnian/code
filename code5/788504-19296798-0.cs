    public static MvcHtmlString GetTypePartial<T>(this HtmlHelper htmlHelper, T model, string viewPrefix = "")
    {
        string typeName = typeof (T).Name;
        string viewName = string.Concat(viewPrefix, typeName);
        return htmlHelper.Partial(viewName, model);
    }
