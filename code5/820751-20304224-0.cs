    private CookieContainer cookies = new CookieContainer();
    private string loginCookie;
    public bool IsLoggedIn { get; set; }
    public void Login()
    {
        var boundary = "---------------------------" + DateTime.Now.Ticks;
        var newLine = Environment.NewLine;
        var propFormat = "--" + boundary + newLine +
            "Content-Disposition: form-data; name=\"{0}\"" +
            newLine + newLine + "{1}" + newLine;
        var req = WebRequest.Create("https://www.fanduel.com/c/CCAuth") as HttpWebRequest;
        req.CookieContainer = cookies;
        req.Method = "POST";
        req.ContentType = "multipart/form-data; boundary=" + boundary;
        string formParams = string.Format(propFormat, "cc_session_id", new SessionIDManager().CreateSessionID(HttpContext.Current));
        formParams += string.Format(propFormat, "cc_action", "cca_login");
        formParams += string.Format(propFormat, "cc_failure_url", "https://www.fanduel.com/p/LoginPp");
        formParams += string.Format(propFormat, "cc_success_url", "https://www.fanduel.com/");
        formParams += string.Format(propFormat, "email", Credentials.ToInsecureString(Credentials.DecryptString(FanDuel.Default.UserName)));
        formParams += string.Format(propFormat, "password", Credentials.ToInsecureString(Credentials.DecryptString(FanDuel.Default.Password)));
        formParams += string.Format(propFormat, "login", "Log in");
        formParams += "--" + boundary + "--";
        byte[] bytes = Encoding.ASCII.GetBytes(formParams);
        req.ContentLength = bytes.Length;
        using (Stream os = req.GetRequestStream())
        {
            os.Write(bytes, 0, bytes.Length);
        }
        var res = req.GetResponse();
        res.Close();
        loginCookie = req.Headers["Cookie"];
        IsLoggedIn = res.ResponseUri == new Uri("https://www.fanduel.com/p/Home");
    }
