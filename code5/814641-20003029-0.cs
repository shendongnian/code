    private void textBox_Enter(object sender, EventArgs e)
    {
        view.passwordInputEnter(sender);
    }
    public void passwordInputEnter(object sender)
    {
        if (sender is TextBox)
        {
           TextBox textBox = (TextBox)sender;
           if (textBox.Text == "Passwort")
           {
                /**/ = string.Empty;
                /**/ = '*';
           }
         }
    }
