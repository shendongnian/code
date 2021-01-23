    private void Button_Click(object sender, RoutedEventArgs e)
    {
                BindingExpression b = BindingOperations.GetBindingExpression(theListBox, ListBox.ItemsSourceProperty);
                b.UpdateSource();
    }
