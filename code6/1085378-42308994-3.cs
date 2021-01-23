    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox CheckBox1 = (e.Row.FindControl("CheckBox1") as CheckBox);
            if (e.Row.Cells[2].Text == "Absent")
            {
                CheckBox1.Enabled = false;
            }
        }
    }
