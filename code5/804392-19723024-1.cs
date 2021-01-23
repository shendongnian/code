    public static MvcHtmlString ManagerButton(this HtmlHelper html, Manager user)
    {
        string buttonForManager = //...
        return new MvcHtmlString(buttonForManager);
    }
    public static MvcHtmlString DeveloperButton(this HtmlHelper html, Developer user)
    {
         string buttonForDeveloper = //...
        return new MvcHtmlString(buttonForDeveloper);
    }
