    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView data = (DataRowView)e.Row.DataItem;
            TextBox txtType = (TextBox)e.Row.FindControl("txtType");
            int status = Convert.ToInt32(data["STATUS"]);
            if (status == 1)
            {
                txtType.Enabled = false;
            }
        }
    }
