    using (var conn = new SQLiteConnection(...))
    {
      conn.Open();
      using (var cmd = new SQLiteCommand(conn))
      {
      }
    }
