    private void DeletForName(string name)
    {
        
        foreach (DataRow row in _Source.Rows)
            if (row["Name"].Equals(name))
            {
                row["Deleted"] = true;
                break;
            }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if ((bool)((System.Data.DataRowView)e.Row.DataItem)["Deleted"])
            {
                ((Button)e.Row.FindControl("Button2")).Enabled = false;
            }
        }
    }
