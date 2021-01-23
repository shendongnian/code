    private void Button_Click(object sender, RoutedEventArgs e)
    {
        //Collapse the first Grid, show the second:
        ContentGrid1.Visibility = System.Windows.Visibility.Collapsed;
        ContentGrid2.Visibility = System.Windows.Visibility.Visible;
    }
