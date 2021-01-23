    using(SqlConnection AWConn = new SqlConnection(conString))
    {
        try
        {
            AWConn.Open();
        }
        catch(SqlException ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
