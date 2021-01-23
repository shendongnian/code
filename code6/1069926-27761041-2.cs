    private void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        SelectedEntityViewModel = new ViewModel.EntityViewModel();
        this.DataContext = SelectedEntityViewModel;
        ImportEntityXML_Click(null, null); //skips clicking the menus
    }
