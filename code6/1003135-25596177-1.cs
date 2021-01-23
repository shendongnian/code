    using (SqlCeConnection con = new SqlCeConnection(conString))
    using (SqlCeCommand query = new SqlCeCommand("SELECT * FROM customers", con))
    {
        con.Open();
        using(SqlCeDataReader reader = query.ExecuteReader())
        {
            //...
        }
    }
