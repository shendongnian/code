    protected void Page_Load(object sender, EventArgs e)
    {
    if (!IsPostBack)
    {
    DataSet3TableAdapters.tbl_energy_reportTableAdapter state;
    state = new DataSet3TableAdapters.tbl_energy_reportTableAdapter();
    DataTable dt = new DataTable();
    dt = state.GetDataByStateInnerJoin();
    DropDownList1.DataSource = dt;
    DropDownList1.DataTextField = "state1";
    DropDownList1.DataValueField = "state1";
    DropDownList1.DataBind();                
    DropDownList1.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select State--", "0"));
    //COMMENT THIS LINE
    //DropDownList2.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Cluster--", "0"));
    }
    }
