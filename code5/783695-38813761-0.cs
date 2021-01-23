     private void SQLTransaction()
            {           
            			try
                        {
            				string sConnectionString = "My Connection String";
                            string query = "UPDATE [dbo].[MyTable] SET ColumnName = '{0}' WHERE ID = {1}";
            				
                            SqlConnection connection = new SqlConnection(sConnectionString);
                            SqlCommand command = connection.CreateCommand();
                            connection.Open();
                            SqlTransaction transaction = connection.BeginTransaction("");
                            command.Transaction = transaction;
                            try
                            {
                                foreach (DataRow row in dt_MyData.Rows)
                                {
                                    command.CommandText = string.Format(query, row["ColumnName"].ToString(), row["ID"].ToString());
                                    command.ExecuteNonQuery();
                                }
                                transaction.Commit();
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                MessageBox.Show(ex.Message, "Error");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Problem connect to database.", "Error");
                        }
            }
