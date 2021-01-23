    public string this[string key]
    {
        get
        {
            string text = this.QueryString[key];
            if (text != null)
            {
                return text;
            }
            text = this.Form[key];
            if (text != null)
            {
                return text;
            }
            HttpCookie httpCookie = this.Cookies[key];
            if (httpCookie != null)
            {
                return httpCookie.Value;
            }
            text = this.ServerVariables[key];
            if (text != null)
            {
                return text;
            }
            return null;
        }
    }
