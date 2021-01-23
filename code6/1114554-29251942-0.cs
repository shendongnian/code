    private void MenuItem_Loaded(object sender, RoutedEventArgs e)
    {
        Fluent.MenuItem menuItem = sender as Fluent.MenuItem;
        if (menuItem != null)
        {
            TextBlock textBlock = menuItem.Template.FindName("textBlockDesc", menuItem) as TextBlock;
            if (textBlock != null)
            {
                textBlock.Visibility = System.Windows.Visibility.Collapsed;
            }
    
            textBlock = menuItem.Template.FindName("textBlock", menuItem) as TextBlock;
            if (textBlock != null)
            {
                textBlock.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            }
        }
    }
