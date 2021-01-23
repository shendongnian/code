    public string this[string key]
    {
        get
        {
            string item = this.QueryString[key];
            if (item != null)
            {
                return item;
            }
            item = this.Form[key];
            if (item != null)
            {
                return item;
            }
            HttpCookie httpCookie = this.Cookies[key];
            if (httpCookie != null)
            {
                return httpCookie.Value;
            }
            item = this.ServerVariables[key];
            if (item != null)
            {
                return item;
            }
            return null;
        }
    }
