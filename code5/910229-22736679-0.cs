    private void clearAllDataMenuItem_Click(object sender, RoutedEventArgs e)
    {
        var symbolDAL = (SymbolDAL)((FrameworkElement) sender).Tag;
        MessageBoxResult confirmDelete = MessageBox.Show("This will remove all data from the database. Continue?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
        if (confirmDelete == MessageBoxResult.Yes)
        {
            symbolDAL.RemoveAll();
        }
    }
