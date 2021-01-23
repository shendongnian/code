    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            DataTable dt = Database.GetDataTable();
            GridView1.DataSource = dt;
            GridView2.DataSoure = dt;
            GridView1.DataBind();
            GridView2.DataBind();
        }
    }
