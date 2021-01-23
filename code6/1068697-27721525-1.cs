    List<string> models = new List<string> { "WebBrowser", "Notebook", "Members"};
    
    foreach (string mod in models)
    {
        using (var dbConn = new SQLiteConnection(app.DBPath))
        {
            SQLiteCommand command = new SQLiteCommand(dbConn);
            command.CommandText = string.Format("DROP TABLE {0};", mod);
            command.ExecuteNonQuery();
        }
    }
