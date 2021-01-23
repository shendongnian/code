    protected void btnSelect_Click(object sender, EventArgs e)
    {
    
        lblAlready.Text = string.Empty; // empty the label that says you already have an item
    
        foreach (GridViewRow row in gvSnacktastic.Rows) // check all the items in the grid view
        {
            CheckBox checkItOut = row.Cells[0].Controls[0] as CheckBox; // get the checkbox
            if (checkItOut != null && checkItOut.Checked) // if the checkbox exists and is checked
            {
                bool storeVariable = true; // store a variable that tells us if we need to add it to the list
    
                foreach (ListItem listItem in lbSelected.Items)  // Loop through list box items to see if we already have it. i haven't used listbox in a long time, this might be slightly wrong 
                {
                    // I'm not sure if it's .Text - compare the text of the listbox item to the checkbox item description
                    if (listItem.Text == row.Cells[3].Text)
                    {
                        lblAlready.Text = "The Item " + listItem.Text + " has already been added."; // make our already added label
                        storeVariable = false; //  we don't need to add this item
                    }
                }
                if (storeVariable) // if we do need to add this item
                {
                    lbSelected.Items.Add(row.Cells[3].Text); // create a new list box item with the check box item's description 
                }
            }
        }
    }
