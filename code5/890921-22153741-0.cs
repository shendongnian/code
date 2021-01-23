    using (var conn = new SqlConnection(connectionString)
    {
        conn.open(); //You only need to open the connection once, so we do it outside the loop
        foreach (var name in names)
        {
            using (var cmd = new SqlCommand("SELECT * FROM myTable where name = @MyName", conn)
            {
                cmd.Parameters.AddWithValue("@MyName", name);
                //Do something with the command
            }
            //The command is disposed of here
        }
    }
    //The connection is disposed of here.
