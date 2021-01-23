    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsCookieDisabled())
          errorMsgLabel.Text = Resources.Resource.BrowserDontSupportCookies;
    }
    private bool IsCookieDisabled()
    {
     string currentUrl = Request.RawUrl;
     if (Request.QueryString["cookieCheck"] == null)
     {
         try
         {
                HttpCookie c = new HttpCookie("SupportCookies", "true");
                Response.Cookies.Add(c);
                if (currentUrl.IndexOf("?") > 0)
                    currentUrl = currentUrl + "&cookieCheck=true";
                else
                    currentUrl = currentUrl + "?cookieCheck=true";
                Response.Redirect(currentUrl);
           }
           catch(Exception ex)
           {
              return false;
           }
     }
     if (!Request.Browser.Cookies || Request.Cookies["SupportCookies"] == null)
          return true;
    return false;
    }
