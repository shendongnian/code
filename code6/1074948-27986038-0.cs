    public Repository(IPlatform platform)
        {
            _platform = platform;
            _platform.SqlitePlatform.SQLiteApi.Config(ConfigOption.Serialized);
            _db = new SQLiteAsyncConnection(() =>
                new SQLite.Net.SQLiteConnectionWithLock(
                _platform.SqlitePlatform,
                new SQLite.Net.SQLiteConnectionString(_platform.DatabasePath, true)));
        }
