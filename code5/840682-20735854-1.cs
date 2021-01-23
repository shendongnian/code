    public async void SyncAll(ViewModel.SyncViewModel syncViewModel)
    {
        _syncViewModel = syncViewModel;
        // lock our synctime
        var syncTime = DateTools.getNow();
        _syncViewModel.MiscStatus = "Sync starting at " + syncTime.ToString();
        await Task.Factory.StartNew(() => {
            // Do lots of other stuff
        });
        _syncViewModel.MiscStatus = String.Format("Sync finished at at {0}, total time taken {1}", 
            DateTools.getNow().ToString(), (DateTools.getNow() - syncTime).ToString());
    }
