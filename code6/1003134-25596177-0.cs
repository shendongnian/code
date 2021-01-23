    using (SqlCeConnection con = new SqlCeConnection(conString))
    using (SqlCeCommand query = new SqlCeCommand("SELECT * FROM customers", con))
    {
        SqlCeDataReader reader = query.ExecuteReader();
    }
