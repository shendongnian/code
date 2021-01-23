    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) CreateTable();        
    }
    public void CreateTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("Plan", typeof(string)));
        dt.Rows.Add("Plan1");
        dt.Rows.Add("Plan1");
        dt.Rows.Add("Plan2");
        dt.Rows.Add("Plan2");
        dt.Rows.Add("Plan3");
        GridView1.DataSource = dt;
        GridView1.DataBind();
    } 
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList drp1 = (DropDownList)sender;
        Label lbl = new Label();
        GridViewRow grow = (GridViewRow)(drp1).Parent.Parent;
        lbl = (Label)grow.FindControl("Label1");
        lbl.Text = "bind  " + drp1.SelectedItem.Text + "  value here";      
    }
