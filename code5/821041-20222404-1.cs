    public static MvcHtmlString EnumToJson<E>(this System.Web.Mvc.HtmlHelper helper) where E : struct, IConvertible
    {
    	var values = from E e in Enum.GetValues(typeof(E)) select String.Format(@"{{""Val"": {0:d}, ""Text"": ""{1}""}}", e, e.ToString());
    	return MvcHtmlString.Create("[" + String.Join(",", values.ToArray()) + "]");
    }
