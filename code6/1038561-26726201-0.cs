    internal static DateTimeOffset GetEarliestDate()
    {
        DateTimeOffset dto;
        using (var db = new SQLite.SQLiteConnection(App.DBPath))
        {
            string sql = "SELECT MIN(dateTimeTaken) FROM PhotraxBaseData";
            dto = (DateTimeOffset)db.ExecuteScalar<DateTime>(sql);
        }
        return dto;
    }
