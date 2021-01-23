    private void passwordTextBox_TextChanged(object sender, EventArgs e)
    {
       SecureString passWord = new SecureString();
       foreach (char c in passwordTextBox.Text.ToCharArray())
       {
         passWord.AppendChar(c);
       }
        passwordGlobalVariable.var = passWord;
    }
