    var connectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
    using (var newConnection = new SqlConnection(connectionString))
    {
        newConnection.Open();
    
        using (var selectCommand = newConnection.CreateCommand())
        {
            selectCommand.CommandType = CommandType.Text;
            select.CommandText ="select request_no from dbo.Request_List where group_no = @groupNumber";
            selectCommand.Parameters.AddWithValue("groupNumber", group_no);
     
            using (dataReader = (SqlDataReader)newCommand.ExecuteReader())
            {
                while (reader.HasRows && reader.Read())
                {
                    using (var insertCommand = newConnection.CreateCommand())
                    {
                        insertCommand.CommandType = CommandType.StoredProcedure;
                        insertCommand.CommandText = "Voucher_Request_Connection";
    
                        var request_no = (int)reader["request_no"];
                        insertCommand.Parameters.Add("@serial_no", serial_no);
                        insertCommand.Parameters.Add("@request_no", request_no);
                        try
                        {
                             if (insertCommand.ExecuteNonQuery() == 1)
                             {
                                 MessageBox.Show("Connection Updated");//just to check the status.tempory 
                             }
                             else
                             {
                                 MessageBox.Show("Connection was not updated " + request_no);
                             }
                        }
                        catch (SqlException xcep)
                        {
                            MessageBox.Show(xcep.Message);
                        }
                        MessageBox.Show(request_no.ToString());// 
                    }
                }
            }
        }
    }
