    cfg.DataBaseIntegration(x =>
    {
      x.ConnectionString = "data source=:memory:";
      x.Driver<SQLite20Driver>();
      x.Dialect<SQLiteDialect>();
      x.ConnectionReleaseMode = ConnectionReleaseMode.OnClose;
    });
