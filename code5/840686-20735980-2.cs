    private void async Button_click(object sender, EventArgs e)
    {
        Sync syncWindow = new Sync(); 
        var viewModel = new SyncViewModel();
        syncWindow.DataContext = viewModel;
        syncWindow.Show();
        syncWindow.Activate();
        await viewModel.Sync();
    }
