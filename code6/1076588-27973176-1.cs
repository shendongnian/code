        DataTable dt = new DataTable() ;
        int rows ;
        
        using ( OdbcConnection connection = new OdbcConnection(connectionString) )
        using ( OdbcCommand command = connection.CreateCommand() )
        using ( OdbcDataAdapter adapter = new OdbcDataAdapter(command) )
        {
          connection.Open();
          command.CommandText = "select * from sys.objects";
          rows = adapter.Fill(dt);
        }
            
        Console.WriteLine( "adapter.Fill() returned {0}",rows);
        Console.WriteLine( "The data table contains {0} rows and {1} columns.",
          dt.Rows.Count ,
          dt.Columns.Count
          );
