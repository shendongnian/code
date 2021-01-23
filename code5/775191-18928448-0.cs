    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }
    protected void BindGrid()
    {
        DataTable dTable = new DataTable();
        dTable.Columns.Add("c1", typeof(bool));
        DataRow r = dTable.NewRow();
        r[0] = false;
        dTable.Rows.Add(r);
        r = dTable.NewRow();
        r[0] = true;
        dTable.Rows.Add(r);
        GridView2.DataSource = dTable;
        GridView2.DataBind();
    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox cb = (CheckBox)e.Row.Cells[0].Controls[0];
            cb.Enabled = true;
        }
    }
