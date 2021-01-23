    protected void GV1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label StatusCustomized = (Label) e.Row.FindControl("StatusCustomized");
            DataRow row = ((DataRowView)e.Row.DataItem).Row; // change type of DataSource if necessary
            string status = row.Field<string>("Status");
            switch(status)
            {
              ....
            }
        }
    }
