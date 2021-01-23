    public static void PostScheduledTasks(List<CellModel> Cells)
    {
       SqlConnection _Connection = new SqlConnection(connectionString);
       SqlCommand _Command = new SqlCommand("ImportData", _Connection);
       _Command.CommandType = CommandType.StoredProcedure;
    
       SqlParameter _TVParam = new SqlParameter();
       _TVParam.ParameterName = "@ImportTable";
       _TVParam.SqlDbType = SqlDbType.Structured;
       _TVParam.Value = SendRows(Cells); // method return value is streamed data
       _Command.Parameters.Add(_TVParam);
    
       try
       {
          _Connection.Open();
    
          // Send the data and process the UPDATE
          _Command.ExecuteNonQuery();
       }
       finally
       {
          _Connection.Close();
       }
    
       return;
    }
