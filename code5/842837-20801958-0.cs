    string insertStmt = "INSERT INTO [order](user_id, date) VALUES (@UserId, @Date); SELECT SCOPE_IDENTITY();";
    using (SqlCommand insertCmd = new SqlCommand(insertStmt, yourSqlConnection))
    {  
        insertCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = xy;
        insertCmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = DateTime.Now;
        yourSqlConnection.Open();
        int newID = (int)insertCmd.ExecuteScalar();
        yourSqlConnection.Close();
    }
