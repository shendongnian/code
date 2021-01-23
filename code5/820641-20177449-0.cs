    using (SqlConnection Conn = new SqlConnection(connectionString1))
    {
        try
        {
            Conn.Open();
            // Here goes your statements for querying your db.
            
        }
        catch (Exception Ex)
        {
            using(SqlConnection Conn2 = new SqlConnection(connectionString2))
            {
                try
                {
                     Conn2.Open();
                     // Here goes your statements for querying your db.
                }
                catch(Exception Ex2)
                {
                     // Here goes your error handling code for the second connection
                }
            }
        }
    }
