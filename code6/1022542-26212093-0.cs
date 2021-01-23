    private List<string> keyCodes;
    private void LoadKeyCodesButton_Click(object sender, RoutedEventArgs e)
    {
        LoadKeyCodes();
        UpdateOutput();
    }
    private void InputTextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateOutput();
    }
    private void LoadKeyCodes()
    {
        // load key codes here
        keyCodes = new List<string>();
        // etc.
    }
    private void UpdateOutput()
    {
        OutputTextBox.Text = EncryptText(InputTextBox.Text);
    }
    private string EncryptText(string input)
    {
        // use keyCodes to encrypt
        return input;
    }
