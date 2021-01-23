    protected void Page_Load(object sender, EventArgs e)
    {
        // Check to see if daysre is in session cache
        if(Session["daysre"] != null)
        {
            // Get list from session cache
            List<string> requestedDays = new List<string>();
            requestedDays = Session["daysre"] as List<string>;
            // Loop through each value in list
            foreach(string day in requestedDays)
            {
                theRequestedDaysStringBuilder.Append(day);
                // Loop through each item in check box list
                foreach (ListItem daysItem in Checkboxlist1.Items)
                {
                    // Check to see if this item needs to be checked by 
                    // comparing its value with current value in list
                    if(daysItem.Value == day)
                    {
                        // We have a match
                        // Make item checked and break out of loop
                        daysItem.Checked = true;
                        break;
                    }
                }
            }
        }
        
        StringBuilder theRequestedDaysStringBuilder = new StringBuilder();
     
        foreach(string day in requestedDays)
        {
            theRequestedDaysStringBuilder.Append(day);
        }
        daysLabel.Text = String.Format("You picked" + theRequestedDaysStringBuilder.ToString());
    }
