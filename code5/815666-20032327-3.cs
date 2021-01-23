    foreach (var user in usersToInsert)
    {
        con.Open();
        SqlCommand com = new SqlCommand();
        com.Connection = con;
        com.CommandText = "INSERT INTO Messages VALUES (@MessageTo, @Subject)";
        com.Parameters.Add("@MessageTo", SqlDbType.Int);
        com.Parameters.Add("@Subject", SqlDbType.NVarChar);
        // this is where you use the iterator variable
        com.Parameters[0].Value = user.UserID;
        com.Parameters[1].Value = "test";
        com.ExecuteNonQuery();
        con.Close();
    }    
