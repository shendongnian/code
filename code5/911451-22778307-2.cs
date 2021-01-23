    protected void buttonSubmit_OnClick(object sender, EventArgs e)
    {
        lblAlready.Text = string.Empty; // empty the label that says you already have an item
    
        foreach (GridViewRow row in gvSnacktastic.Rows) // check all the items in the grid view
        {
            var checkItOut = row.FindControl("checkItOut") as CheckBox; // get the checkbox
    
            // if the checkbox exists and is checked
            if (checkItOut == null || !checkItOut.Checked)
            {
                continue;
            }
    
            var storeVariable = true; // store a variable that tells us if we need to add it to the list
    
            // Loop through list box items to see if we already have it. i haven't used listbox in a long time, this might be slightly wrong 
            foreach (ListItem listItem in this.lbSelected.Items)  
            {
                // I'm not sure if it's .Text - compare the text of the listbox item to the checkbox item description
                if (listItem.Text != row.Cells[3].Text)
                {
                    continue;
                }
    
                // make our already added label
                this.lblAlready.Text = "The Item " + listItem.Text + " has already been added."; 
    
                // we don't need to add this item
                storeVariable = false;
            }
    
            // if we do need to add this item
            if (storeVariable) 
            {
                this.lbSelected.Items.Add(row.Cells[3].Text); // create a new list box item with the check box item's description 
            }
    
            checkItOut.Checked = false;
        }
    }
