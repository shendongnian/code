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
        int position = 0;
        int take = Constants.PreferredFetchQuantity;
        int total = MoreThan200xDoubleValue;
        
        while (CheckCancellationToken == false && position <= total)
        {
            var Data = await Task.Run(FetchDataRowsSlowly(position, take));
            // the remainder is a nice readable callback
            position += take;
            UpdateProgressBar(position);
            foreach(var row in Data) SomeGridOrSomething.Add(row);
            // ...
        }
    }
    private Task<DataTable> FetchDataRowsSlowly(int start, int count)
    {
        var db = WhateverDbContextOrWebAPICallOrWhatever();
        // return datatable, the framework will handle the Task<>
        return db.GiantTable.Skip(start).Take(count).ToDataTable();
    }
                
