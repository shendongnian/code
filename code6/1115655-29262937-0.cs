    private void WinsFormCodeBehindMethod()
    {
        var result = SearchForUpdatesAsync().Result;
        MessageBox.Show(result.ToString());
    }
    public async Task<bool> SearchForUpdatesAsync()
    {
        _updateAvailable = await _updateManager.SearchForUpdatesAsync();
        return true;
    }
