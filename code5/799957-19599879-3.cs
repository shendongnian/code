    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e) 
    { 
        if (e.CommandName == "Select") 
        { 
            int index = Convert.ToInt32(e.CommandArgument); 
            GridViewRow selectedRow = GridView1.Rows[index];
            // Find the account number label to get the text value for the text box
            Label theAccountNumberLabel = selectedRow.FindControl("LabelAccountNumber") as Label;
            // Make sure we found the label before we try to use it
            if(theAccountNumberLabel != null)
            {
                AccountNumber.Text = theAccountNumberLabel.Text;
            }
            // Follow the same pattern for the other labels to get other text values          
        }
    }
