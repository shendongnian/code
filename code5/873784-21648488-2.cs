    private void radButtonSaveChanges_Click(object sender, EventArgs e)
    {
        try
        {
            if (radTextBoxReferenceNumber.Text == "")
            {
               RadMessageBox.Show(this, " You must enter a reference number", ....);
               // Stop the WinForms manager to close this form
               this.DialogResult = DialogResult.None;
               return; 
            }
            else
            {
                // all ok.... let's return the DialogResult property of the button
                // Do nothing, the WinForms manager gets the DialogResult of this button and
                // assign it to the form closing it....
            }
        }
    ]
