     public static void showConnections(SqlConnection sqlConn)
     {
            Console.WriteLine("mySqlConnection.ConnectionString = " +
              sqlConn.ConnectionString);
            Console.WriteLine("mySqlConnection.ConnectionTimeout = " +
                sqlConn.ConnectionTimeout);
            Console.WriteLine("mySqlConnection.Database = " +
                sqlConn.Database);
            Console.WriteLine("mySqlConnection.DataSource = " +
                sqlConn.DataSource);
            Console.WriteLine("mySqlConnection.PacketSize = " +
                sqlConn.PacketSize);
            Console.WriteLine("mySqlConnection.ServerVersion = " +
                sqlConn.ServerVersion);
            Console.WriteLine("mySqlConnection.State = " +
                sqlConn.State);
            Console.WriteLine("mySqlConnection.WorksationId = " +
                sqlConn.WorkstationId);
            Console.WriteLine("TEST");
     }
     public static void Main()
     {
            string connectionString = "some string";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            showConnections(sqlConnection);
            sqlConnection.Open();
            //close database
            sqlConnection.Close();
            Console.ReadLine();
     }
