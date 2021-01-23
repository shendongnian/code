    protected void Page_Load(object sender, EventArgs e)
    {
        this.GridView2.RowDataBound += GridView2_RowDataBound;
       
        BindGrid();
    }
    void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.Cells[0].GetType() == typeof(System.Web.UI.WebControls.DataControlFieldCell))
        {
            TableCell tc = e.Row.Cells[0];
            if (tc.Controls.Count > 0)
            {
                CheckBox cb = (CheckBox)tc.Controls[0];
                if (!(cb == null))
                {
                    cb.Enabled = true;
                }
            }
        }
    }
    private void BindGrid()
    {
        DataTable dTable = new DataTable();
        dTable.Columns.Add("c1", typeof(bool));
        DataRow r = dTable.NewRow();
        r[0] = false;
        dTable.Rows.Add(r);
        r = dTable.NewRow();
        r[0] = true;
        dTable.Rows.Add(r);
        //CheckBoxField chkField = new CheckBoxField();
        //chkField.DataField = "c1";
        //chkField.HeaderText = "CheckBox";
        //chkField.ReadOnly = false;
        //GridView1.Columns.Add(chkField);
        GridView2.DataSource = dTable;
        GridView2.DataBind();
    }
}
