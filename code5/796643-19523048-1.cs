    private void ClearAllClick(object sender, RoutedEventArgs e)
    {
        ClearTextChildren(ContentStackPanel);
    }
    private void ClearTextChildren((Panel container)
    {
        foreach (var element in container.Children)
        {
            if (element is TextBox)
                ((TextBox)element).Text = String.Empty;
            else if (element is Panel)
                ClearChildren((Panel)element);
        }
    }
