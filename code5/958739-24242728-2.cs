    private void Button_Click(object sender, RoutedEventArgs e)
    {
                BindingExpression b = BindingOperations.GetBindingExpression(TextBoxEditName, TextBox.TextProperty);
                b.UpdateSource();
    }
