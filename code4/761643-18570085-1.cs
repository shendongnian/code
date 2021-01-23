    using (SqlConnection conn = new SqlConnection(sqlBuilder.ConnectionString))
            {
                string schemaName = "your_schemaName";
                string tableName = "your_tableName";
                SqlCommand command 
                  = new SqlCommand((string.Format(@"
                    SELECT column_name
                    FROM information_schema.key_column_usage
                    WHERE TABLE_SCHEMA = '{0}' AND TABLE_NAME = '{1}'
                      AND OBJECTPROPERTY(object_id(constraint_name), 'IsPrimaryKey') = 1
                    ORDER BY table_schema, table_name", schemaName, tableName)), conn
                                   );
                conn.Open();                
                SqlDataReader reader = command.ExecuteReader();
                try
                {                    
                    while (reader.Read())
                    {
                        Console.WriteLine(String.Format("{0}", reader[0]));
                    }
                }
    
                finally
                {
                    reader.Close();
                }
    
            }
