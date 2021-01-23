    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack) {
            GetData();  //Database fetch
        }
    }
    protected void Page_PreRender(object sender, EventArgs e) {
        gvSource.DataSource = (DataTable)Session["dtFrom"];
        gvSource.DataBind();
        gvDest.DataSource = (DataTable)Session["dtTo"];
        gvDest.DataBind();
    }
