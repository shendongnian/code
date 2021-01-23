    public void Update<T>(string stmt, string table) where T : new()
    {
        using (var conn = new SQLiteConnection(App.ConnectionString))
        {
            var result = conn.Query<T>("SELECT * FROM " + table);
            if (result != null)
            {
                conn.RunInTransaction(() =>
                    {
                        SQLiteCommand cmd = conn.CreateCommand(stmt);
                        cmd.ExecuteNonQuery();
                    });
            }
        }
    }
