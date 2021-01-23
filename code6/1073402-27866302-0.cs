    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["YOUR_VAR_NAME"]==null)
        {
            Response.Redirect("~/default.aspx");
        }
    }
