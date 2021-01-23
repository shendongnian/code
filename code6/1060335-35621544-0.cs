    public async Task<int> Vacuum()
    {
         return Db.SqliteConnection.ExecuteAsync("VACUUM;");
    }
   
