            public static void LogActivity(string text, byte[] data)
            {
                // todo: just for bourse demo, fuck critics
                Task.Factory.StartNew(() =>
                {
                    var connection =
                        new SqlConnection(ConfigurationManager.ConnectionStrings["LogConnectionString"].ConnectionString);
                    var command = new SqlCommand { Connection = connection, CommandType = CommandType.Text };
                    try
                    {
                        command.CommandText = @"
    insert into Logs (Value, CheckSum, Data)
    values (@value, @checksum, @data)
    ";
                        command.Parameters.Add("@value", SqlDbType.NVarChar).Value = text;
                        command.Parameters.Add("@checksum", SqlDbType.NVarChar).Value = text.ComputeChecksum();
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
                });
        }
