    SqlConnectionStringBuilder connStr = new SqlConnectionStringBuilder();
                connStr.IntegratedSecurity = true;
                connStr.InitialCatalog = "testDB";
                connStr.DataSource = "127.0.0.1";
    
                using (SqlConnection conn = new SqlConnection(connStr.ToString()))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "insert into myTable(name, sku, tax) values (@name, @sku, @tax); SELECT SCOPE_IDENTITY();";
                        cmd.CommandType = CommandType.Text;
    
                        cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = "name value";
                        cmd.Parameters.Add("@sku", SqlDbType.VarChar).Value = "sku value";
                        cmd.Parameters.Add("@tax", SqlDbType.Int).Value = 1;
    
                        int id = Convert.ToInt32(cmd.ExecuteScalar());
                        Console.WriteLine("value: {0}", id);
    
                    }
                }
