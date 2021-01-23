    protected void Page_Load(object sender, EventArgs e)
    {
        ...
        if(!IsPostBack)
        {
            dtcStartDate.Enabled = true;
            dtcBuildStartDate.Enabled = true;
        }
        ...
    }
