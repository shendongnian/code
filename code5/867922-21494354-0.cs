    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            grdActivity.DataSource = GetDataSource();
            grdActivity.DataBind();
        }
    }
    private DataTable GetDataSource()
    {
        dsActivity myDataSet = new dsActivity();
        myDataSet = clsDataLayer.GetActivity(Server.MapPath("DB.mdb"));
        return myDataSet.Tables["tblActivity"];
    }
    protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdActivity.PageIndex = e.NewPageIndex;
        grdActivity.DataSource = GetDataSource();
        grdActivity.DataBind();
    }
