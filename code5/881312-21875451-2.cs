    private void TextBoxExactSize_TextChanged(object sender, TextChangedEventArgs e)
    {
      pm_RetrievedBindingExpression = TextBoxExactSize.GetBindingExpression(TextBox.TextProperty);
      pm_RetrievedBindingExpression.UpdateSource();
    }
