     string sql =
            "INSERT INTO [order] (user_id, date) VALUES (@user_id, @date); "
            + "SELECT CAST(scope_identity() AS int)";
        using (SqlConnection conn = new SqlConnection(connString))
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@user_id", SqlDbType.VarChar);
        
            try
            {
                conn.Open();
                ord_id = (Int32)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        return (int)ord_id ;
