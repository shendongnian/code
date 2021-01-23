    public SQLiteConnection(ISQLitePlatform sqlitePlatform, string databasePath, bool storeDateTimeAsTicks = false, IBlobSerializer serializer = null)
        : this(
            sqlitePlatform, databasePath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create, storeDateTimeAsTicks, serializer)
    {
    }
