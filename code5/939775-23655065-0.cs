    protected void Page_Load(object sender, EventArgs e)
    {
        bool projectIdAvailable = this.Request.QueryString["ProjectID"] != null;
        if (!projectIdAvailable)
        {
            // Load list with buttons
            // PostBackUrl = "Reporting.aspx?ProjectID=0"
        }
        else
        {
            if(!IsPostBack)
            {
                LoadReporting();
            }
        }
    }
