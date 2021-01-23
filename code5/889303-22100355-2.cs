    string _data = "Website=url:www.site1.com,isdefault:true,url:www.site2.com,isdefault:true";
        List<WebSiteAddress> _websiteList = _data
            .Split(new string[]{"url:"}, StringSplitOptions.RemoveEmptyEntries)
            .Select(site => site.Split(new char[]{','}, StringSplitOptions.RemoveEmptyEntries))
            .Where(site => site.Length > 1)
            .Select(site => new WebSiteAddress { Url = site[0], IsDefault = site[1].ToLower().Replace("isdefault:", "") == "true"})
            .ToList();
