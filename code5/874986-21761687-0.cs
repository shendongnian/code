    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack) {
            GetData(); //Database fetch saves 2 DataTables to session variables
        }
        gvSource.DataSource = (DataTable)Session["dtFrom"];
        gvSource.DataBind();
        gvDest.DataSource = (DataTable)Session["dtTo"];
        gvDest.DataBind();
    }
