    if (!(e.Control && char.IsLetterOrDigit((char) e.KeyCode)))
    {
        return;
    }
    txtBox.Text += (new KeysConverter()).ConvertToString(e.KeyCode);
    e.Handled = true;
