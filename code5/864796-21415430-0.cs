    void OnSettingsButtonClicked()
    {
        var viewModel = new SettingsViewModel();
        var window = new SettingsWindow();
       
        window.DataContext = viewModel;
        window.Show();
    }
