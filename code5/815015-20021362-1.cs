    public interface IHtmlHelperActionInvoker
    {
        MvcHtmlString Action(HtmlHelper helper, string action, string controller, CMSObject model);
    }
    public class HtmlHelperActionInvoker : IHtmlHelperActionInvoker
    {
        public MvcHtmlString Action(HtmlHelper helper, string action, string controller, CMSObject model)
        {
            return helper.Action(action, controller, model);
        }
    }
