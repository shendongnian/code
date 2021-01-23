    using (SqlConnection conn = new SqlConnection(sqlBuilder.ConnectionString))
                {
                    string schemaName = "dbo";
                    string tableName = "CompPrimaryKey1";
                    SqlCommand command = new SqlCommand(@"
                      SELECT column_name
                      FROM information_schema.key_column_usage
                      WHERE TABLE_SCHEMA = @schemaName AND TABLE_NAME = @tableName
                        AND OBJECTPROPERTY(object_id(constraint_name), 'IsPrimaryKey') = 1
                      ORDER BY table_schema, table_name", conn);
                    command.Parameters.Add("@schemaName", SqlDbType.VarChar, 100).Value = schemaName;
                    command.Parameters.Add("@tableName", SqlDbType.VarChar, 100).Value = tableName;
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
