    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserType"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            filldrpclass();
            pnltimetable.Visible = false; //initially hidden
        }
    }
