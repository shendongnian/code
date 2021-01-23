    private void convertButton_Click(object sender, EventArgs e)
    {
       //if else arguments for radio buttons
        if (string.IsNullOrWhiteSpace(enterTextBox.Text))
        {
            MessageBox.Show("Please enter a value");
            return;
        }       
         /*Your remaining code here*/
        decimal measurementDecimal = decimal.Parse(enterTextBox.Text);    
       
