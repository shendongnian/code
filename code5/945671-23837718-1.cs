    private void buttonOK_Click(object sender, MouseEventArgs e)
    {
        // Perform some logic to validate the inputs and if something is wrong return false
        if(SomeLogicToAcceptTheForm() == false)
        {
            // Inform the user of the errors and stop the closing process of the Formular instance 
            MessageBox.Show("Your input is not valid");
            this.DialogResult = DialogResult.None;
        }
        // If your logic accepts the input, then the code continue at this point and the property 
        // DialogResult of the buttonOK (DialogResult.OK) is accepted automatically to become the 
        // DialogResult value of the current instance of the form. This will cause the form to exit
        // from the ShowDialog call and you can read the current form DialogResult value.
 
    }
