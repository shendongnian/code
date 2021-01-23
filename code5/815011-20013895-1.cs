     public static class SomeHtmlHelperClass
     {
        static SomeHelperClass() {
            HtmlHelperActionFunc = () => new HtmlHelperActionInvoker();
        }
        public static Func<HtmlHelperActionInvoker> HtmlHelperActionFunc { get; set; }
        public static MvcHtmlString RenderCMSObject(this HtmlHelper helper, CMSObject cmsObject)
        {
            var actionName = string.IsNullOrEmpty(cmsObject.ActionName)
                ? "Index"
                : cmsObject.ActionName;
            var controllerName = string.IsNullOrEmpty(cmsObject.ControllerName)
                ? "Default"
                : cmsObject.ControllerName;
            var helperAction = HtmlHelperActionFunc();
            return helperAction.InvokeAction(helper, actionName, controllerName);
        }
      }
