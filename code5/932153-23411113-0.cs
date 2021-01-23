            SqlConnection conn
            try
            {
                conn = new SqlConnection(connString)
                SqlCommand cmd = new SqlCommand("Drop Table sometable", conn);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                //
            }
            finally
            {
               if(conn != null)
               {
                    conn.Dispose()
               }
           }
