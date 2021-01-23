    var tables = new List<string> { "WebBrowser", "Notebook", "Members" };
    using (var dbConn = new SQLiteConnection(app.DBPath))
    {
        dbConn.RunInTransaction(() =>
        {
            foreach (string table in tables)
            {
                dbConn.DropTable(table);
            }
        });
    }
