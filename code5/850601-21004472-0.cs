    protected void Page_Load(object sender, EventArgs e)
        {
        lblStatus.Visible = false;
        if(!Page.IsPostBack)
        {
                if(Request.Cookies["temp"] != null)
                {
                    txtUsername.Text = Request.Cookies["temp"].Values["u"];
                    txtPassword.Text = Request.Cookies["temp"].Values["p"];
                }
        }
        }
