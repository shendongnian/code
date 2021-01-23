    private void radButtonSaveChanges_Click(object sender, EventArgs e)
    {
        try
        {
            if (radTextBoxReferenceNumber.Text == "")
            {
               RadMessageBox.Show(this, " You must enter a reference number", ....);
               this.DialogResult = DialogResult.None;
               return; 
            }
            else
            {
                // all ok.... let's return the DialogResult property of the button
            }
        }
    ]
