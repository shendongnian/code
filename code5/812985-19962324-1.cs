    private bool isValidTextBox(TextBox box, string message)
    {
        if(string.IsNullOrEmpty(box.Text))
        {                
            MessageBox.Show(message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information); 
            box.Focus();
            return false;
        }
        return true;
    }
