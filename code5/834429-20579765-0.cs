    String DbFile = "E:\tumblr_db.sdf";
    private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
              .Database(
                SQLiteConfiguration.Standard
                  .UsingFile(DbFile)
              )
              .Mappings(m =>
                m.FluentMappings.AddFromAssemblyOf<Form1>())
              .ExposeConfiguration(BuildSchema)
              .BuildSessionFactory();
        }
    private static void BuildSchema(Configuration config)
        {
            
            if (!File.Exists(DbFile))
            {
                new SchemaExport(config)
                  .Create(false, true);
            }
            else
            {
                FileInfo info = new FileInfo(DbFile);
                long size = info.Length;
                if (size == 0)
                {
                    new SchemaExport(config).Create(false, true);
                }
            }
        }
