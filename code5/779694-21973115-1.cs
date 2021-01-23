    private void TextBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key.Equals(Key.Enter))
        {
            PasswordBox.Focus();
        }
    }
