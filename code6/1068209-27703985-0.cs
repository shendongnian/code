    // define query as a string
    string query = "SELECT ..... FROM ... WHERE ......";
    // create connection and command in "using" blocks
    using (SqlConnection conn = new SqlConnection(-your-connection-string-here-))
    using (SqlCommand cmd = new SqlCommand(conn, query))
    {
        // set up e.g. parameters for your SqlCommand
        
        // open the connection, execute the query, close the connnection again
        conn.Open();
        
        // for a SELECT, use ExecuteReader and handle the reader (or use SqlDataAdapter to fill a DataTable)
        // for UPDATE, INSERT, DELETE just use a ExecuteNonQuery() to run the command
        using (SqlDataReader rdr = cmd.ExecuteReader())
        {
            while (rdr.Read())
            {
               // handle the data from the reader
            }
            // close reader
            rdr.Close();
        }
        
        conn.Close();
    }
