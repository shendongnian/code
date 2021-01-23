    protected void LoadData_Click(Object sender, EventArgs e)
    {
        // Execute a task without blocking the calling method
        Task.Factory.StartNew(() => { LoadDataAsync(); });
        // method finishes, does not block on the task
    }
    private async void LoadDataAsync()
    {
        // Await the load and use the remainder of this method as callback
        UpdateProgressBar();
        var Data = await Task.Run(FetchDataRowsSlowly());
        // the remainder is a nice readable callback
        UpdateProgressBar();
        foreach(var row in Data) SomeGridOrSomething.Add(row);
        // ...
    }
    private Task<DataTable> FetchDataRowsSlowly()
    {
        var db = WhateverDbContextOrWebAPICallOrWhatever();
        // return datatable, the framework will handle the Task<>
        return db.GetAllThatData();
    }
                
