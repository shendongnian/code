    // define SQL statement to use, with a parameter
    string sqlStmt = "insert into dbo.MyTbl (DateT) values (@transferDate)";
    
    // define connection and command objects
    using (SqlConnection conn = new SqlConnection(your-connection-string-here))
    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
    {
        // add parameter and set value
        cmd.Parameters.Add("@transferDate", SqlDbType.SmallDateTime).Value = DateTime.Now;
        
        // open connection, execute SQL query, close connection
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }    
