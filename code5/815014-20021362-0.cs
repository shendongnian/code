    public static class SomeHtmlHelperClass
    {
        static SomeHtmlHelperClass()
        {
            ActionInvoker = new HtmlHelperActionInvoker();
        }
        public static IHtmlHelperActionInvoker ActionInvoker { get; set; }
        public static MvcHtmlString RenderCMSObject(this HtmlHelper helper, CMSObject cmsObject)
        {
            var actionName = string.IsNullOrEmpty(cmsObject.ActionName)
                ? "Index"
                : cmsObject.ActionName;
            var controllerName = string.IsNullOrEmpty(cmsObject.ControllerName)
                ? "Default"
                : cmsObject.ControllerName;
            return ActionInvoker.Action(helper, actionName, controllerName, cmsObject);
        }
    }
