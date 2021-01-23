    protected void checkall_CheckedChanged(object sender, EventArgs e)
    {
        // Cast the sender of the event to a check box, because the check box created this event
        CheckBox theCheckBox = sender as CheckBox;
        
        if (theCheckBox.Checked)
        {
            foreach (GridViewRow row in ApplicationsGridView.Rows)
            {   
                // Here is where you want to search for the existing check boxes, not create new ones
                CheckBox cb = row.FindControl("checkboxes") as CheckBox;
                cb.Checked = true;
            }
        }
    }
