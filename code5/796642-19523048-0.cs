    private void ClearAllClick(object sender, RoutedEventArgs e)
    {
        ClearChildren(ContentStackPanel);
    }
    private void ClearChildren(Panel container)
    {
        foreach (var element in container.Children)
        {
            if (element is TextBox)
                ((TextBox)element).Text = String.Empty;
            else if (element is Panel)
                ClearChildren((Panel)element);
        }
    }
