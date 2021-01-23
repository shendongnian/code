    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            tbLogin.Text = Response.Cookies["login"].Value;
        }
    }
    
    protected void Button1_Click1(object sender, EventArgs e)
    {
        Response.Cookies.Add(new HttpCookie("login", tbLogin.Text));
    }
