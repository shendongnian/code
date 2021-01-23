    string dbPath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "db.sqlite");          
    using (var db = new SQLiteConnection(dbPath))
    {
        db.RunInTransaction(() =>
        {            
           // ....
        });
    }
