    protected void ddl1_SelectedIndexChanged(object sender, EventArgs e)
    {
        var theDropDownList = sender as DropDownList;
        // Make sure we have the drop down list before we try to use it
        if(theDropDownList != null)
        {
            // Find the naming container of the drop down list
            var theRepeaterItem = control.NamingContainer as RepeaterItem;
        
            // Make sure we have the repeater item before we try to use it
            if (theRepeaterItem != null)
            {
                // Find the the label by name
                var theLabel = theRepeaterItem.FindControl("label1") as Label;
           
                // Make sure we have the label before we try to use it
                if(theLabel != null)
                {  
                    // Do what you want with the label here
                    theLabel.Text = "Message";
                }
            }
        }
    }
