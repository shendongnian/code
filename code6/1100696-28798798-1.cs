    private async void SomeMethodHere()
    {
        ...
        var myItems = new List<Table1>();
        foreach (JObject content2 in jarrTAR.Children<JObject>())
        {
            // create and/or populate collection here
        }
            
        await InsertAsync("my.sqlite.path", myItems);
    }
    public Task InsertAsync(string dbPath, IEnumerable<Table1> items)
    {
        return Task.Run(() =>
            {
                using (var connection = new SQLiteConnection(dbPath))
                    connection.RunInTransaction(() => connection.InsertAll(items));
            });
    }
