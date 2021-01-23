    private bool isSearching = false;
    private object lockObj = new object();
    private void btnSearch_Click(object sender, EventArgs e)
    {
        lock (lockObj)
        {
            if (isSearching)
                return;
            else
                isSearching = true;
        }
        // shows loading animation
        ShowPleaseWait(Translate("Searching data. Please wait..."));
        ProcessSearch();
    }
    
    private async void ProcessSearch()
    {
        // do other stuff
        isSearching = false;
    }
