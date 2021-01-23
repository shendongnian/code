    private void addButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            ...
            (Application.Current.MainWindow as MainWindow).ReloadUsers();
        }
        catch (Exception ex)
        {
            ...
        }
    }
