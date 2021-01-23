          private void ExecuteCommandAsync(string sql)
          {
            SqlConnection conn = new SqlConnection(connectString + "Async=true;");
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            conn.Open();
            cmd.BeginExecuteNonQuery(new AsyncCallback(AsyncCommandCompletionCallback), cmd);
           }
         private void AsyncCommandCompletionCallback(IAsyncResult result)
         {
            SqlCommand cmd = null;
            try
            {
                cmd = (SqlCommand)result.AsyncState;
                cmd.EndExecuteNonQuery(result);
                
                // Do some more work here...
            }
            catch (Exception ex)
            {
                // Handle errors here
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
            }
         }
