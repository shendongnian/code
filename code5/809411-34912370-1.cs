    var db = config.Build()
             .UsingConnectionString("cs")
             .UsingProvider<SqlServerDatabaseProvider>()
             .UsingIsolationLevel(IsolationLevel.Chaos)
             .Create();
     db.IsolationLevel.ShouldBe(IsolationLevel.Chaos);
