    private void TestConnection()
    {
        using (var db = new SystemDBContext())
        {
            var conn = db.Database.Connection;           
            conn.Open();
        }
    }
