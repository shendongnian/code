    private void PasswordBoxPasswordChanged(object sender, RoutedEventArgs e)
    {
        PasswordBox pb = sender as PasswordBox;
        if (pb != null)
        {
            pb.GetBindingExpression(PasswordBox.PasswordProperty).UpdateSource();
        }
    }
    private void TextBoxTextChanged(object sender, TextChangedEventArgs e)
    {
        TextBox tb = sender as TextBox;
        if (tb != null)
        {
            tb.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }
    }
