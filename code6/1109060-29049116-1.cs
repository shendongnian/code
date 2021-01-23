    using System.Web.Optimization;
     public static class CheckBoxHelper
     {
        public static MvcHtmlString ListCheckbox(this HtmlHelper helper, string actionName, int value,string jsPath)
        {
            var builder = new StringBuilder();
            builder.Append(Scripts.Render(jsPath).ToHtmlString());
            builder.AppendFormat("<input type='checkbox' value='{1}' onclick='Action_{0}()'></input>", actionName, value);
            return new MvcHtmlString(builder.ToString());
        }
      }
    
