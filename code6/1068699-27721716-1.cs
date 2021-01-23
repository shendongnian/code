    var tables = new List<string> { "WebBrowser", "Notebook", "Members"};
    foreach (string table in tables)
    {
        using (var dbConn = new SQLiteConnection(app.DBPath))
        {
            dbConn.RunInTransaction(() =>
            {
                dbConn.DropTable(table);
            });
        }
    }
