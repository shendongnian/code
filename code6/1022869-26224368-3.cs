    private static HtmlString MyHtmlHelper(this HtmlHelper htmlHelper, string viewName, object model)
    {
        string output = htmlHelper.Partial(viewName, model).ToHtmlString();
        //TODO: Conditional string parsing based on output
        string formattedOutput = output.SomeOperation();
        return new HtmlString(formattedOutput);
    }
