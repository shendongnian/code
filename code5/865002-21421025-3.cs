     protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack) {
                   Username.Text = Request.Headers["displayname"];
                   DateUpdated.Text = DateTime.Now.ToString("M/dd/yy");
                   Session["Username"] = Request.Headers["displayname"];
                }
            }
    protected void Page_Load(object sender, EventArgs e)
            {     
                if (!IsPostBack) {
                   Username.Text = (string) (Session["Username"]);
                   DateUpdated.Text = DateTime.Now.ToString("M/dd/yy");
                }
            }
