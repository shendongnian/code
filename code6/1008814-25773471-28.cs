    public static void test()
    {
       SqlConnection _Connection = new SqlConnection("{connection string}");
       SqlCommand _Command = new SqlCommand("ImportData", _Connection);
       _Command.CommandType = CommandType.StoredProcedure;
    
       SqlParameter _TVParam = new SqlParameter();
       _TVParam.ParameterName = "@ImportTable";
       _TVParam.TypeName = "dbo.ImportStructure";
       _TVParam.SqlDbType = SqlDbType.Structured;
       _TVParam.Value = GetFileContents(); // return value of the method is streamed data
       _Command.Parameters.Add(_TVParam);
    
       try
       {
          _Connection.Open();
    
          _Command.ExecuteNonQuery();
       }
       finally
       {
          _Connection.Close();
       }
       return;
    }
