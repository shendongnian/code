    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("jobApplyUID", typeof(string));
            dt.Rows.Add(System.Guid.NewGuid().ToString());
            dt.Rows.Add(System.Guid.NewGuid().ToString());
            dt.Rows.Add(System.Guid.NewGuid().ToString());
            dt.Rows.Add(System.Guid.NewGuid().ToString());
            dt.Rows.Add(System.Guid.NewGuid().ToString());
            uxGrid.DataSource = dt;
            uxGrid.DataBind();
        }
    }
    protected void uxShowDetails_Click(object sender, EventArgs e)
    {
        this.uxJobApplyUID.Text = (((sender as Button).NamingContainer as GridViewRow).FindControl("uxHiddenJobApplyUID") as HiddenField).Value;
    }
