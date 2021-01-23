    Status data = GetStatusFoo();
    using (SqliteConnection con = new SqliteConnection("Data Source=" + Config.SQLITE_DB_FILE + ";DbLinqProvider=sqlite;"))
    using (DataContext db = new DataContext(con))
    {
        Table<Status> statuses = db.GetTable<Status>();
        statuses.InsertOnSubmit(data);
        db.SubmitChanges();
    }
