    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        // Only look in data rows, ignore header and footer rows
        if (e.Item.ItemType == ListItemType.AlternatingItem || 
            e.Item.ItemType == ListItemType.Item)
        {
            // Get a data view row object so we can reference the data 
            // in the repeater by the bound field names      
            DataRowView theDataRowView = e.Item.DataItem as DataRowView;
            // Make sure we got the data row view before we try to use it
            if(theDataRowView != null)
            {
                // Get the value of status from the control that holds the value
                string theStatus = theDataRowView.Row["Status"];
                // Find the download link control
                LinkButton theLinkButtonDownload = e.Item.FindControl("LinkButton1") as LinkButton;
                if(theStatus.ToLower() == "approve")
                {
                    if(theLinkButtonDownload != null)
                    {
                        theLinkButtonDownload.Visible = true;
                    }
                }
                else
                {
                    if(theLinkButtonDownload != null)
                    {
                        theLinkButtonDownload.Visible = false;
                    }
                }
            }
        }
    }
