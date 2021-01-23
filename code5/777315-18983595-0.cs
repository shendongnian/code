    public void Page_Load(object sender, EventArgs e)
    {
        if(Request.QueryString["id"] == "4")
        {
            Response.Redirect("http://www.google.com");
        }
        else
        {
            Response.Redirect("http://www.yahoo.com");
        }
    }
