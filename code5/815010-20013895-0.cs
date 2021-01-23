       public class HtmlHelperActionInvoker {
        public virtual MvcHtmlString InvokeAction(HtmlHelper helper, string action, string controller)      {
            return helper.Action(action, controller);
        }
    }
