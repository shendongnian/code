    protected void Page_Load(object sender, EventArgs e)
    {
        // Disable Export button
        this.btnExport.Enabled = false;
        if(!Page.IsPostBack)
        {
            DataTable userDataTable = new DataTable();
            gridViewTest.DataSource = userDataTable;
            gridViewTest.DataBind();
            // Store a reference to this DataTable for later use.
            Session["userDataTable"] = userDataTable;
        }
    }
