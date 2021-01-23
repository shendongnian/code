    public class TesatableHtmlHelperAction : HtmlHelperActionInvoker
    {
        public string Controller { get; set; }
        public string Action { get; set; }
        public override MvcHtmlString InvokeAction(HtmlHelper helper, string action, string controller) {
            Action = action;
            Controller = controller;
            return new MvcHtmlString("");
        }
    }
   
