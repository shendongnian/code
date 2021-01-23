    protected void gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRow row   = ((DataRowView)e.Row.DataItem).Row;
            string name   = row.Field<string>("Name");
            string dept   = row.Field<string>("Dept");
            string work   = row.Field<string>("Work");
            string status = row.Field<string>("Status");
            bool isCompleted = status == "Completed"; // or status.Equals("Completed", StringComparison.CurrentCultureIgnoreCase)
            e.Row.BackColor = isCompleted ? Color.Green : Color.White;
        }
    }
