    // bind custom method to authenctionrequest event handler.
    public Global(): base()
    {
        this.AuthenticateRequest += new EventHandler(this.MyAuthenticationRequest);
    }
    // the custom method
    void MyAuthenticationRequest(object sender, EventArgs e)
    {
        var myPage = HttpContext.Current.Request.Url.ToString();
        myPage = myPage.Replace(Request.Url.GetLeftPart(UriPartial.Path),
            String.Empty);
        if (String.IsNullOrEmpty(myPage))
        {
            if (Request.Cookies["started"] != null)
            {
                String flg = Request.Cookies["started"].Value;
                if (flg == "true")
                {
                    return;
                }
            }
            Response.Cookies.Add(new HttpCookie("started", "true"));
            Response.Redirect("Index.html");
        }
    }
