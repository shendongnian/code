    using (var conn = GetConnection())
    {
        using (var comm = xxxxxxx)
        {
            conn.Open();
            using (var rdr = comm.ExecuteReader())
            {
                // xxxxx
            }
        }
    }
