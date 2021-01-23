    //splitting url string for textbox using name value collection
        NameValueCollection collection = new NameValueCollection();
        string currentUrl = HttpContext.Current.Request.Url.Query;
        string [] result = currentUrl.Split('&');
        foreach (string r in result)
        {
            string[] parts = HttpUtility.UrlDecode(r).Split('=');
            if (parts.Length > 0)
            {
                string key = parts[0].Trim(new char[] { '?', ' ' });
                string val = parts[1].Trim();
                collection.Add(key, val);
            }
        }
