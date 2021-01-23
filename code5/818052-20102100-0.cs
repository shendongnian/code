    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if(Request.QueryString["ID"] != null)
            {
                YourButton.Text = "Update";
            }
            else
            {
                YourButton.Text = "Add";
            }
        }
    }
