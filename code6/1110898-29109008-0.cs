    namespace MvcApplication.Helpers
    {
        public static class TextboxExtensions
        {
            public static HtmlString CustomTextBox(this HtmlHelper helper, string labelName, NameValueCollection parameters)
            {
                var returnValue = string.Empty;
                if (parameters == null || parameters.Count <= 0) return new HtmlString(returnValue);
                
                var attributes = parameters.AllKeys.Aggregate("", (current, key) => current + (key + "=" + "'" + parameters[key] + "' "));
    
                returnValue = String.Format("<div class='col-xs-12'><label>{0}</label>" +
                                            "<div><input " + attributes + "></div></div>", labelName);
    
                return new HtmlString(returnValue);
            }
        }
    }
