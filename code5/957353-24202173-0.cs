    string[] allLines = File.ReadAllLines(@"C:\Table.csv");
    
                var query = from line in allLines
                            let data = line.Split(',')
                            select new
                            {
                                FieldName = data[0],
                                Description = data[1]
                            };
    
     
                try
                {
                    string connection = "my connection string";
                    using (SqlConnection conn = new SqlConnection(connection))///add your connection string
                    {                    
                        SqlCommand command = new SqlCommand();
                        conn.Open();
    
                        using (SqlTransaction trans = conn.BeginTransaction())
                        {
                            command.Connection = conn;
                            command.Transaction = trans;
    
                            foreach (var item in query)
                            {
                                String sql = string.Format("ALTER TABLE MyTable ADD {0} Decimal(18,6)", item.FieldName.ToString());
                                command.CommandText = sql;
                                command.ExecuteNonQuery();
                            }
    
                            trans.Commit();
                        }
    
    
                        conn.Close();
                        conn.Open();
                        SqlTransaction transaction = conn.BeginTransaction();
    
                        using (SqlCommand cmd = new SqlCommand("sp_addextendedproperty", conn, transaction))
                        {
                            
                             
                                cmd.CommandType = CommandType.StoredProcedure;
                               
                                
                                foreach (var item in query)
                                {
                                    cmd.Parameters.Clear();
    
                                    cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = "MS_Description";
                                    cmd.Parameters.Add("@value", SqlDbType.VarChar).Value = item.Description.ToString();
                                    cmd.Parameters.Add("@level0type", SqlDbType.VarChar).Value = "SCHEMA";
                                    cmd.Parameters.Add("@level0name", SqlDbType.VarChar).Value = "dbo";
                                    cmd.Parameters.Add("@level1type", SqlDbType.VarChar).Value = "TABLE";
                                    cmd.Parameters.Add("@level1name", SqlDbType.VarChar).Value = MyTable;
                                    cmd.Parameters.Add("@level2type", SqlDbType.VarChar).Value = "COLUMN";
                                    cmd.Parameters.Add("@level2name", SqlDbType.VarChar).Value = item.FieldName.ToString();
    
    
                                    cmd.ExecuteNonQuery();
                                }
    
                                transaction.Commit();
                            
                        }                    
                    }
                }
                catch (Exception ex)
                {
                     
                    MessageBox.Show(ex.Message);
                }   
