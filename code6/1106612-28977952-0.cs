    using (OdbcConnection conn = new OdbcConnection())
    {
        conn.Open();
        using(OdbcCommand comm = new OdbcCommand(sql, conn))        
        using(OdbcDataReader dr = comm.ExecuteReader())
        {
            while (dr.Read())
            {
                //codes here...
            }
        }            
    }
