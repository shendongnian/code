    private bool isSearching = false;
    private void btnSearch_Click(object sender, EventArgs e)
    {
        if (isSearching)
            return;
        // shows loading animation
        ShowPleaseWait(Translate("Searching data. Please wait..."));
        ProcessSearch();
    }
    
    private async void ProcessSearch()
    {
        isSearching = true;
        // do other stuff
        isSearching = false;
    }
