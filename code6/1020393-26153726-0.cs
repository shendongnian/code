    private const string LoginUrl = "https://accounts.google.com/ServiceLoginAuth";
    private const string WalletUrl = "https://wallet.google.com/merchant/pages";
    private readonly DateTime _unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    private const string Username = "YourUserName@gmail.com";
    private const string Password = "YourPassword";
    private readonly DateTime _startDate = new DateTime(2014, 9, 1);
    private readonly DateTime _endDate = new DateTime(2014, 9, 30);
    public Form1()
    {
        InitializeComponent();
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        string orders = GetLoginHtml();
    }
    private string GetLoginHtml()
    {
        var request = (HttpWebRequest)WebRequest.Create(LoginUrl);
        var cookieJar = new CookieContainer();
        request.Method = "POST";
        request.ContentType = "application/x-www-form-urlencoded";
        request.CookieContainer = cookieJar;
        using (var requestStream = request.GetRequestStream())
        {
            string content = "Email=" + Username + "&Passwd=" + Password;
            requestStream.Write(Encoding.UTF8.GetBytes(content), 0, Encoding.UTF8.GetBytes(content).Length);
            using (var sr = new StreamReader(request.GetResponse().GetResponseStream()))
            {
                string html = sr.ReadToEnd();
                string galxValue = ParseOutValue(html, "GALX");
                return GetLoginHtml2(galxValue, cookieJar);
            }
        }
    }
    private string GetLoginHtml2(string galx, CookieContainer cookieJar)
    {
        var request = (HttpWebRequest)WebRequest.Create(LoginUrl);
        request.Method = "POST";
        request.ContentType = "application/x-www-form-urlencoded";
        request.CookieContainer = cookieJar;
        using (var requestStream = request.GetRequestStream())
        {
            string content = "Email=" + Username + "&Passwd=" + Password + "&GALX=" + galx;
            requestStream.Write(Encoding.UTF8.GetBytes(content), 0, Encoding.UTF8.GetBytes(content).Length);
            using (var sr = new StreamReader(request.GetResponse().GetResponseStream()))
            {
                string html = sr.ReadToEnd();
                return GetLoginHtml3(galx, cookieJar);
            }
        }
    }
    private string GetLoginHtml3(string galx, CookieContainer cookieJar)
    {
        var request = (HttpWebRequest)WebRequest.Create(WalletUrl);
        request.Method = "GET";
        request.ContentType = "text/xml";
        request.CookieContainer = cookieJar;
        using (var sr = new StreamReader(request.GetResponse().GetResponseStream()))
        {
            string html = sr.ReadToEnd();
            string bcid = ParseOutBcid(html);
            string oid = ParseOutOid(html);
            string cid = ParseOutCid(html);
            string orders = GetOrders(cookieJar, bcid, oid, cid, _startDate, _endDate);
            return orders;
        }
    }
    private string GetOrders(CookieContainer cookieJar, string bcid, string oid, string cid, DateTime startDate, DateTime endDate)
    {
        var st = (long)(startDate.ToUniversalTime() - _unixEpoch).TotalMilliseconds;
        var et = (long)(endDate.ToUniversalTime() - _unixEpoch).TotalMilliseconds;
        var request = (HttpWebRequest)WebRequest.Create(WalletUrl + "/u/0/bcid-" + bcid + "/oid-" + oid + "/cid-" + cid + "/purchaseorderdownload?startTime=" + st + "&endTime=" + et);
        request.Method = "GET";
        request.ContentType = "text/xml";
        request.CookieContainer = cookieJar;
        using (var sr = new StreamReader(request.GetResponse().GetResponseStream()))
        {
            string html = sr.ReadToEnd();
            return html;
        }
    }
    private string ParseOutValue(string html, string value)
    {
        int ndx1 = html.IndexOf("<input name=\"" + value + "\"", StringComparison.Ordinal);
        int ndx2 = html.IndexOf("value=", ndx1, StringComparison.Ordinal);
        return html.Substring(ndx2 + 7, html.IndexOf("\"", ndx2 + 7, StringComparison.Ordinal) - ndx2 - 7);
    }
    private string ParseOutBcid(string html)
    {
        int ndx1 = html.IndexOf("bcid-", StringComparison.Ordinal);
        int ndx2 = html.IndexOf("/oid", ndx1, StringComparison.Ordinal);
        return html.Substring(ndx1 + 5, ndx2 - ndx1 - 5);
    }
    private string ParseOutOid(string html)
    {
        int ndx1 = html.IndexOf("/oid-", StringComparison.Ordinal);
        int ndx2 = html.IndexOf("/cid", ndx1, StringComparison.Ordinal);
        return html.Substring(ndx1 + 5, ndx2 - ndx1 - 5);
    }
    private string ParseOutCid(string html)
    {
        int ndx1 = html.IndexOf("/cid-", StringComparison.Ordinal);
        string retval = "";
        ndx1 = ndx1 + 5;
        while (char.IsNumber(html[ndx1]))
        {
            retval = retval + html[ndx1];
            ndx1++;
        }
        return retval;
    }
