     /// <summary>
     /// Called when user change textbox value
     /// </summary>
     /// <param name="sender">Represent object of sender (i.e text box itself)</param>
     /// <param name="e">Reesent eventArgs</param>
     private void withBox_TextChanged(object sender, EventArgs e)
            {
                TextBox tmpTextBox = (TextBox)sender; // Doing type casting sender to textbox so that we can access property of it.
                decimal withdraw;
                bool bIsParsed = Decimal.TryParse(tmpTextBox.Text, out withdraw); // TryParse method return false if there is any problem in process of doing parsing of string to decimal
                if (!bIsParsed)
                {
                    MessageBox.Show("Please enter valid number");
                }
            }
