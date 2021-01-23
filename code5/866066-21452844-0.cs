    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        UpdateDisplayBasedOnCookie();
      }
    }
    public void UpdateDisplayBasedOnCookie()
    {
      LiteralCookie.Text = Request.Cookies["TestCookie"] == null ? "No" : "Yes";
    }
    protected void ButtonSetCookieClick(object sender, EventArgs e)
    {
      SetCookie();
      UpdateDisplayBasedOnCookie();
    }
    private void SetCookie()
    {
      HttpCookie myCookie = new HttpCookie("TestCookie");
      myCookie.Values.Add("Username", "Matt");
      myCookie.Expires = DateTime.Now.AddHours(12);
      Response.Cookies.Add(myCookie);
    }
