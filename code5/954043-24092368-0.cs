    private void UIElement_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        bool isCyrillic = Regex.IsMatch(e.Text, @"\p{IsCyrillic}");
        e.Handled = !isCyrillic;
    }
