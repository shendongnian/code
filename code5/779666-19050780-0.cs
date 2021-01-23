    protected void DeleteButton_Click(object sender, EventArgs e)
    {
        foreach(GridViewRow row in dbRecordsContent.Rows)
        {
            // Only look for check boxes in data rows, ignoring header 
            // and footer rows
            if (row.RowType == DataControlRowType.DataRow)
            {
                if (((CheckBox)row.FindControl("myCheckBox")).Checked)
                {
                    // Do delete logic here
                }
            }
        }
    }
