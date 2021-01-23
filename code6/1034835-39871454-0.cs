             try
                {
                    comm = conn.CreateCommand();
                    comm.CommandText = "ALTER TABLE [AS_" + TableName + "_DATA] ADD [" + FieldName + "] VARCHAR(30)";
                    comm.CommandType = CommandType.Text;
                    comm.CommandTimeout = 120;   //120 seconds
                    conn.Open();
                    comm.ExecuteNonQuery();
                }
                catch (SqlException err)
                {
                    MessageBox.Show("SqlException Error : " + err.Message.ToString());
                }
