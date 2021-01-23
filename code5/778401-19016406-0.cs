    List<Key> _pressedKeys = new List<Key>();
    private void TextBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (_pressedKeys.Contains(e.Key))
            return;
        _pressedKeys.Add(e.Key);
        PrintKeys();
        e.Handled = true;
    }
    private void TextBox_KeyUp(object sender, KeyEventArgs e)
    {
        _pressedKeys.Remove(e.Key);
        PrintKeys();
        e.Handled = true;
    }
    private void PrintKeys()
    {
        StringBuilder b = new StringBuilder();
        b.Append("Combination: ");
        foreach (Key key in _pressedKeys)
        {
            b.Append(key.ToString());
            b.Append("+");
        }
        b.Length--;
        Console.WriteLine(b.ToString());
    }
    private void TextBox_LostFocus(object sender, RoutedEventArgs e)
    {
        _pressedKeys.Clear();
    }
