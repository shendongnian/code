    using (SQLiteCommand cmd = new SQLiteCommand(qry, conn))
    {
        cmd.Parameters.Add(new SQLiteParameter("UPCCode", upc));
        using (SQLiteDataReader rdr = cmd.ExecuteReader())
        {
            while (rdr.Read())
            {
                // Set inv properties
                break; // (if you only want the first item returned)
            }
        }
    }
    return inv;
