    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    if (e.Row.RowType == DataControlRowType.DataRow)
    {
            e.Row.Cells[0].Visible = false;   //0 is autogenerate edit column index
            e.Row.Cells[1].Visible = false;  // 1  is autogenerate delete column index
    }
    }
