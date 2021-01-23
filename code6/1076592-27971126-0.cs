    private void FetchDataFromDB(object sender, System.ComponentModel.DoWorkEventArgs args)
    {
        // slow reading from DB on worker thread
        var listFromDb = this.ReadDataFromDb().ToList();
  
        // send populated result to main thread
        if (this.InvokeRequired)
        {
            this.Invoke(AddItemsToUiList(listFromDb)));
        }
    }
