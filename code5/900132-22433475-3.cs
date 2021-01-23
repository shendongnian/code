    protected void Page_Load(object sender, EventArgs e)
        {
            string CrUserID = Request.QueryString["LogInUser"].ToString();
            string Result = Request.QueryString["Result"].ToString();
            if(Request.RawUrl.Contains("?status"))
            {
               string val=Request["status"];
               status_lbl.Text = val;   
               status_lbl.Visible = true;
            }
            if (!IsPostBack)
            {
                if (string.IsNullOrWhiteSpace(CrUserID) || string.IsNullOrWhiteSpace(Result))
                {
                    Response.Redirect("Login Page.aspx");
                }
    
                else
                {                    
                    UserID.Text = Request.QueryString["LogInUser"].ToString();
                    status_lbl.Visible = false;
                    GridView1.Visible = false;
                }
            }
        }
