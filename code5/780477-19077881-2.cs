    if (e.Modifiers == (Keys)Enum.Parse(typeof(Keys), "keys1", true)
        && e.KeyCode == (Keys)Enum.Parse(typeof(Keys), "keys2", true))
    {
        string keyPressed = e.KeyCode.ToString();
        MessageBox.Show(keyPressed);
    }
