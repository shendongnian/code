    public async Task LoadAppModel()
    {
        var userTask = store.GetUserAsync();
        var securityTask = store.GetSecurityAsync();
        var settingsTask = store.GetLocalSettingsAsync();
        await Task.WhenAll(userTask, securityTask,settingsTask);
        app.User = userTask.Result;
        app.Security = securityTask.Result;
        app.LocalSettings = settingsTask.Result;
        
        Contract.Assume(app.User != null);
        Contract.Assume(app.Security != null);
        Contract.Assume(app.LocalSettings != null);
    }
