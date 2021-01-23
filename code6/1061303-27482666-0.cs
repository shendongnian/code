    string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(constr))
            {
                connection.Open();
    
                SqlCommand command = new SqlCommand("SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME =@TableName", connection);            
                command.Parameters.Add("@TableName", SqlDbType.NVarChar).Value = listSelectTable.Text;
    
                
                    listSelectColumn.Items.Clear();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listSelectColumn.Items.Add((string)reader["COLUMN_NAME"]);
                        }
                        listSelectColumn.Items.Add("ALL");
                    }
                
                connection.Close();
            }
