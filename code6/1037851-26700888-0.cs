    using(OleDbConnection conn = new OleDbConnection(conString))
    using(OleDbCommand comm = conn.CreateCommand())
    {
        // Execute your INSERT query here.
        // Also check your INSERT is successfull or not.
        // Assing your SELECT statement to your CommandText property
        using(OleDbDataReader reader = comm.ExecuteReader())
        {  
           //
        }
    }
