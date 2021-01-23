    private void myTextBox_Leave(object sender, EventArgs e)
    {
        Regex pattern = new Regex(@"^((\+){0,1}91(\s){0,1}(\-){0,1}(\s){0,1}){0,1}9[0-9](\s){0,1}(\-){0,1}(\s){0,1}[1-9]{1}[0-9]{7}$");
        if (pattern.IsMatch(myTextBox.Text))
        {
            MessageBox.Show("OK");
        }
        else
        {
            MessageBox.Show("Invalid phone number");
        }
    }
