    string folder = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
    var conn = new SQLiteAsyncConnection (System.IO.Path.Combine (folder, "stocks.db"));
    conn.CreateTableAsync<Stock>().ContinueWith (t => {
        Console.WriteLine ("Table created!");
    });
