    public static ISession AddTable( string TableName, List<String> TableNames, Databases db )
    {
        if ( !SessionFactories.ContainsKey( db ) )
        {
            SessionFactories.Add( db, null );
        }
        var _cfg = new Configuration();
        _cfg.Configure( System.IO.Path.Combine( DatabaseConfigurationFiles[db] ) );
        // Add table to the database
        File.Move( @"C:\Generic.hbm.xml", @"C:\" + TableName + ".hbm.xml" );
        string aux = File.ReadAllText(@"C:\" + TableName + ".hbm.xml");
        aux = aux.Replace("generic", TableName);
        File.WriteAllText( @"C:\" + TableName + ".hbm.xml", aux );
        _cfg.AddFile(@"C:\" + TableName + ".hbm.xml");
        var update = new SchemaUpdate( _cfg );
        var sb = new StringBuilder();
        TextWriter output = new StringWriter( sb );
        update.Execute( true, true );
        aux = aux.Replace( TableName, "generic" );
        File.WriteAllText( @"C:\" + TableName + ".hbm.xml", aux );
        File.Move( @"C:\" + TableName + ".hbm.xml", @"C:\Generic.hbm.xml" );
        // Add dynamic tables to my mappings list.
        if ( SessionFactories[ db ] == null )
        {
            var configuration = new Configuration();
            configuration.Configure( DatabaseConfigurationFiles[ db ] );
            configuration.AddAssembly( Assembly.GetExecutingAssembly() );
            string filename = @"C:\Generic.hbm.xml";
            string entityname = "generic";
            string a = "";
            for ( int i = 0 ; i < TableNames.Count() ; i++ )
            {
                File.Move( filename, @"C:\" + TableNames[ i ] + ".hbm.xml" );
    
                filename = @"C:\" + TableNames[ i ] + ".hbm.xml";
                a = File.ReadAllText( filename );
    
                a = a.Replace( entityname, TableNames[ i ] );
                entityname = TableNames[ i ];
                File.WriteAllText( filename, a );
                configuration.AddFile( filename );
                configuration.ClassMappings.Last().EntityName = entityname;
                configuration.ClassMappings.Last().Table.Name = entityname;
                configuration.ClassMappings.Last().DiscriminatorValue = entityname;
            }
            File.Move( filename, @"C:\Generic.hbm.xml" );
            filename = @"C:\Generic.hbm.xml";
            a = File.ReadAllText( filename );
            entityname = TableNames.Last();
            a = a.Replace( entityname, "generic" );
            File.WriteAllText( filename, a );
    
            SessionFactories[ db ] = configuration.BuildSessionFactory();                
        }
        else
        {
            DBStub.CloseSession( db );
            return DBStub.OpenSession( db, TableNames );
        }
        return SessionFactories[ db ].OpenSession();
    }
