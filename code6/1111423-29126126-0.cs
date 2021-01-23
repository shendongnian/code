    public string tags()
    {
    	string url = "http://www.testdomain.com/data.aspx";
        string html = Story();
        DataTable tags = LoadAllTags();
    
        if (tags.Rows.Count > 0)
        {
    		foreach(var row in tags.Rows)
    		{
    			foreach(var column in tags.Columns)
    			{
    				var tag = column.ToString();
    				var path = string.Format("{0}?SearchName={1}", url, HttpUtility.UrlEncode(tag);
    				var link = string.Format("<a href=\"{0}\">{1}</a>", path, tag);
    				html = html.Replace(tag, link);
    			}
    		}
        }
        return html;
    }
