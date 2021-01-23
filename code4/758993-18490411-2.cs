    protected void GridView1_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        // Only interested in each data row, not header or footer, etc.
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
            // Find the Label2 control in the row
            Lable theLabel = (Label)e.row.FindControl("Label2");
            // Make sure control is not null
            if(theLabel != null)
            {
                // Cast the bound to an object we can use to extract the value from
                DataRowView rowView = (DataRowView)e.Row.DataItem;
                // Get the value for CallDestination field in data source
                string callDestinationValue = rowView["CallDestination"].ToString();
                // Find out if CallDestination is 10 digits or 4 digits
                if(callDestinationValue.Length == 10)
                {
                    theLabel.Text = String.Format("{0:(###) ###-####}", Convert.ToInt64(rowView["CallDestination"]));
                }
                if(callDestinationValue.Length == 4)
                {
                    theLabel.Text = "Ext: " + callDestinationValue;
                }
            }
        }
    }
  
