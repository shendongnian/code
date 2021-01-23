    if (Conn.State == ConnectionState.Closed)
         Conn.Open();
    
    if (Conn.State == ConnectionState.Open)
    {
         cmd = new SqlCommand("insert into [AppLog] values (@strbuff, 
                                                            @time, 
                                                            @Processing, 
                                                            @userName", Conn);
         cmd.Parameters.AddWithValue("@strbuff", strbuff);
         cmd.Parameters.AddWithValue("@time", time);
         cmd.Parameters.AddWithValue("@Processing", Processing);
         cmd.Parameters.AddWithValue("@userName", userName);
         cmd.ExecuteNonQuery();
         Conn.Close();
    }
    
