    private async void LoginUsername_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Char keyChar = (Char)System.Text.Encoding.ASCII.GetBytes(e.Text)[0];
            if (Regex.IsMatch(keyChar.ToString(), @"[^a-zA-Z0-9]"))
            {
                e.Handled = true;
            }
        }
