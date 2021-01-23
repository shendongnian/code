    private void TextBlock_LostFocus(object sender, RoutedEventArgs e)
    {
        TextBox b = sender as TextBox;
        if (b == null)
        {
            return;
        }
        MultiBindingExpression mb = BindingOperations.GetMultiBindingExpression(b, TextBox.TextProperty);
        mb.UpdateSource();
    }
