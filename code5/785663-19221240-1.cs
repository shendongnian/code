    public static string Urls(this HtmlHelper helper, string value)
    {  
    	var items = value.Split(';'); // use your delimiter
    	var sb = new StringBuilder();
    	foreach(var i in items)
    	{
            if(IsUrl(i)) // write a static method that checks if the value is a valid url
    	        sb.Append("<a href=\"" + i + "\">" + i + "</a>,");
            else
                sb.Append(i + ",");
    	}
    	return sb.ToString();
    }
