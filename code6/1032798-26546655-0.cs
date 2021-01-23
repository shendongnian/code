    // When this is true it means our code is changing the text
    private bool updatingTextWithCode = false;
    private void MacAdressTextBox_TextChanged(object sender, EventArgs e)
    {
        if (updatingTextWithCode)
        {
            // Our code is doing the update, so just reset the variable
            updatingTextWithCode = false;
        }
        else
        {
            // The user is updating the text, so process the contents
            var newText = "";
            // Store the mac address without the ':' characters
            var plainText = MacAdressTextBox.Text.Replace(":", "");
            // Then add ':' characters in correct positions to 'newText'
            for (int i = 1; i <= plainText.Length; i++)
            {
                newText += plainText[i - 1];
                if (i % 2 == 0) newText += ":";
            }
            // Set our global variable and update the text
            updatingTextWithCode = true;
            MacAdressTextBox.Text = newText;
            MacAdressTextBox.Select(MacAdressTextBox.TextLength, 0);
        }            
    }
