    public static string Urls(this HtmlHelper helper, string value)
    {  
    	var urls = value.Split(';'); // use your delimiter
    	var sb = new StringBuilder();
    	foreach(var url in urls)
    	{
    		sb.Append("<a href=\"" + url + "\">" + url + "</a>");
    	}
    	return sb.ToString();
    }
