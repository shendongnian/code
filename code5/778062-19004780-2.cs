    Task _pendingSearch = null;
    private void startSearchBtn_Click(object sender, EventArgs e)
    {
        // check if is _pendingSearch != null and still pending here
        _pendingSearch = Search(files, 
            selectTxcDirectory.SelectedPath, status).ContinueWith((finishedTask) => 
    	{
    		// Place your completion callback code here
    	}, TaskScheduler.FromCurrentSynchronizationContext);
    }
    
    private static async Task Search(List<string> files, string path, Label statusText)
    {
        // ...
    }
