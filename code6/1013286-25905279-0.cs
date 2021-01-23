    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            tbLogin.Text = Response.Cookies["login"].Value;
        }
    }
