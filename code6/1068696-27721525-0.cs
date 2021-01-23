    List<string> models = new List<string> { "WebBrowser", "Notebook", "Members"};
    
    foreach (string mod in models)
    {
        using (var dbConn = new SQLiteConnection(app.DBPath))
        {
            string sql = string.Format("DROP TABLE {0};", mod); 
            SQLiteCommand command = new SQLiteCommand(sql, dbConn);
            command.ExecuteNonQuery();
        }
    }
