    protected void Page_Load(object sender, EventArgs e)
    {
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Grid", "headerLock();", true);
        if (!IsPostBack)
        {
            //When IsPostBack is false, ddlJournal should be enabled
            Bindddl();
            BindGrid(null);
            ddlJournal.Enabled = true;
        }
        else
        {
            //Else, IsPostBack is true, so, ddlJournal should be disabled              
            ddlJournal.Enabled = false;
        }
    }
