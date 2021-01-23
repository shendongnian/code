    public static class ActionLinkButtonHelper
    {
        /// <summary>
        /// Add a back button that generates a Javascript browser-back 
        /// </summary>
        /// <param name="htmlHelper">HtmlHelper we are extending</param>
        /// <param name="buttonText">Text to display on back button - defaults to "Back"</param>
        /// <param name="actionName">Name of action to execute on click</param>
        /// <param name="controller">Name of optional controller to send action to</param>
        /// <returns></returns>
        public static MvcHtmlString BackButton(this HtmlHelper htmlHelper, string buttonText="Back", string actionName="index", string controller=null, object routeValuesObject = null)
        {
            // Note: "Index is provided as a default
            return ActionLinkButton(htmlHelper, buttonText, actionName, controller, routeValuesObject, new { onclick = "history.go(-1);return false;" });
        }
    }
