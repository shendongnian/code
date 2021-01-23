    private bool CreateSchema()
    {
        using (var db = new SQLiteConnection(DbConstants.DbFileWithPath))
        {
            db.CreateTables(typeof (Doc), typeof(DocAttachment));
        }
        return true;
    }
