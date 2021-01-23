    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        // Only look in data rows, ignore header and footer rows
        if (e.Item.ItemType == ListItemType.AlternatingItem || 
            e.Item.ItemType == ListItemType.Item)
        {
            // Get the value of status from the control that holds the value
            // I am guessing the name, because your markup is not posted
            Label labelStatus = e.Item.FindControl("lblStatus") as Label;
            // Make sure we found the label before we try to use it
            // because the as operator returns null for a failed cast attempt
            if(labelStatus != null)
            {
                string theStatus = labelStatus.Text.Trim();
                // Find the download link control
                // Again, guessing because of lack of markup that the control is a LinkButton
                LinkButton theLinkButtonDownload = e.Item.FindControl("linkDownload") as LinkButton;
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
