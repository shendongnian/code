    public static MvcHtmlString EnumToJson&lt;T&gt;(this System.Web.Mvc.HtmlHelper helper) where T : struct, IConvertible
    {
    
        var values = from T e in Enum.GetValues(typeof(T)) select String.Format(@"{{""Value"": {0:d}, ""Text"": ""{1}""}}", e, e.ToString());
        return MvcHtmlString.Create("[" + String.Join(",", values.ToArray()) + "]");
    
    }
