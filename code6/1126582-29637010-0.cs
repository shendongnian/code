    try
                {
                connection.Open();
                transaction = connection.BeginTransaction();
              for (int i = 0; i < number; i++)
            {
                 cmd = new SqlCommand();
                //SqlTransaction transaction;
                cmd.Transaction = transaction;
                cmd.Connection = connection;
                    cmd.Parameters.Clear();
                    cmd.CommandText = "InsertMsg";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = IDs[i];
                    cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = names[i];
                    cmd.Parameters.Add("@age", SqlDbType.DateTime).Value = age;
                    cmd.ExecuteNonQuery();
                    data[i] =  IDs[i];
                    transaction.Commit();
                     }
              connection.Close();
                       return data;
            }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    data[0]="Error";
                    return data;
                }
