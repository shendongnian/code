     private void Page_Load(object sender, EventArgs e)
     {
    Response.Buffer= true;
    Response.ExpiresAbsolute=DateTime.Now.AddDays(-1d);
    Response.Expires =-1500;
    Response.CacheControl = "no-cache";
    if(Session["SessionId"] == null)
    {
    Response.Redirect ("Loginpage.aspx");
     }
    }
    }
