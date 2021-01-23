    protected void Page_Load(object sender, EventArgs e)
    {
        Uri parenturl = new Uri(Request.UrlReferrer.OriginalString);
        string qyr = parenturl.Query;
        NameValueCollection col = HttpUtility.ParseQueryString(qyr);
        String kvalue = col["k"];
        String mvalue = col["m"];
    }
