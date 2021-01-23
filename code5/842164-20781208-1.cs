            public static void LogActivity( byte[] data)
            {
          
                    var connection =
                        new SqlConnection(ConfigurationManager.ConnectionStrings["LogConnectionString"].ConnectionString);
                    var command = new SqlCommand { Connection = connection, CommandType = CommandType.Text };
                    try
                    {
                        command.CommandText = @"
    insert into Logs (Data)
    values ( @data)
    ";
                        command.Parameters.Add("@data", SqlDbType.VarBinary, data.Length).Value = data;
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                        connection.Dispose();
                    }
                    catch (Exception ex)
                    {
                        Log(ex);
                    }
           
        }
