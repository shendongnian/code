    public void Window_Loaded(object sender, RoutedEventArgs e)
    {
        textbox1.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        textbox2.GetBindingExpression(TextBox.TextProperty).UpdateSource();
    }
