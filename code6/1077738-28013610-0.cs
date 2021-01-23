            SqlDataAdapter SDA = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"SELECT        table1.column2, table2.column2
            FROM          table2 
            INNER JOIN
               table1 ON table2.ID = table1.table2ID
             WHERE        (table1.column2= @something)";
            cmd.Connection = conn;
            SDA.SelectCommand = cmd;
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                SDA.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
