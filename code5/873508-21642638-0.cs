    public static class Html
    {
        public static string RoleActionLink(this HtmlHelper html, string role, string linkText, string actionName, string controllerName)
        {
            return html.ViewContext.HttpContext.User.IsInRole(role)
                ? html.ActionLink(linkText, actionName, controllerName)
                : String.Empty;
        }
    }
