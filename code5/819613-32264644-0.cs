      public static SqlDataReader ExecuteReader(String connectionString, String commandText,
          CommandType commandType, params SqlParameter[] parameters) {
         SqlConnection conn = new SqlConnection(connectionString);
         using (SqlCommand cmd = new SqlCommand(commandText, conn)) {
            cmd.CommandType = commandType;
            cmd.Parameters.AddRange(parameters);
            conn.Open();
            // When using CommandBehavior.CloseConnection, the connection will be closed when the 
            // IDataReader is closed.
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
         }
      }
