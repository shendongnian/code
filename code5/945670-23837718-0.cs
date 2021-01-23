    private void buttonOK_Click(object sender, MouseEventArgs e)
    {
        // Perform some logic to validate the inputs and if something is wrong return false
        if(SomeLogicToAcceptTheForm() == false)
        {
            // Inform the user of the errors and stop the closing process of the Formular instance 
            MessageBox.Show("Your input is not valid");
            this.DialogResult = DialogResult.None;
        }
 
    }
