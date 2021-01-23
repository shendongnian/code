    foreach (GridViewRow row in GridView1.Rows)
    {
        // Only look in data rows
        if (row.RowType == DataControlRowType.DataRow || 
            row.RowType == DataControlRowType.EmptyDataRow)
        {
            // Find the delete button by ID
            Button theDeleteButton = row.FindControl("ButtonDelete") as Button;
            // Verify the button was found before we try to use it
            if(theDeleteButton != null)
            {
                // Make the button invisible
                theDeleteButton.Visible = false;
            }
        }
    }
