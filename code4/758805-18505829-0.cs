    public void TextCompositionEventHandler(object sender, TextCompositionEventArgs e)
    {
        // if the last pressed key is not a number or a full stop, ignore it
        return e.Handled = !e.Text.All(c => Char.IsNumber(c) || c == '.');
    }
    public void PreviewKeyDownEventHandler(object sender, KeyEventArgs e)
    {
        // if the last pressed key is a space, ignore it
        return e.Handled = e.Key == Key.Space;
    }
