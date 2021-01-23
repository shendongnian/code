    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (CheckBox2.Checked)
            {
                e.Row.Cells[2].Visible = false;
            }
            else 
            {
                e.Row.Cells[2].Visible = true;
            }
        }
    }
