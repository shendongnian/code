        using ( OdbcConnection connection = new OdbcConnection(connectionString) )
        using ( OdbcCommand command = connection.CreateCommand() )
        {
          connection.Open();
          command.CommandText = "select * from sys.objects";
          using ( OdbcDataReader reader = command.ExecuteReader() )
          {
            int rowcount = 0 ;
            while ( reader.Read() )
            {
              ++rowcount;
            }
          }
        }
        
