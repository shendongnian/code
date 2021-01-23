    protected void SomeButton_OnClick(Object sender, EventArgs e)
    {
        // A new task is not necessarily a new thread!
        Task.Factory.StartNew(() => PopulateSomeControl());
    }
    private async void RequestDataAndPopulateTheControl()
    {
        Statusbar.Text = "Loading from DB...";
        // this blocks only this method, not the UI thread.
        var data = await RequestData();
   
        // data is now available
        foreach(var whatever in data.ToList())
            SomeControl.Items.Add(whatever);
        Statusbar.Text = "Ready.";
    }
    private async Task<DataTable> RequestData()
    {
        var db = new YourDbContext();
    
        return db.SomeDbSet().ToDataTable();
    }
