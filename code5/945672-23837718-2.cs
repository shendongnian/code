    private void buttonOK_Click(object sender, MouseEventArgs e)
    {
        // Perform some logic to validate the inputs and if something is wrong return false
        if(SomeLogicToAcceptTheForm() == false)
        {
            // Inform the user of the error
            MessageBox.Show("Your input is not valid");
            // Stop the closing process of this Formular instance 
            this.DialogResult = DialogResult.None;
        }
        // If your logic accepts the input, then the code continue at this point 
        // This will cause the form to exit from the ShowDialog call 
        // and you can read the current form DialogResult value.
 
    }
