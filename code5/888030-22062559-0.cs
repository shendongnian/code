    using (var rdr = cmd.ExecuteReader())
    {
        using (DataSet ds = new DataSet())
        {
            using (DataTable dt = new DataTable())
            {
                ds.Tables.Add(dt);
                ds.EnforceConstraints = false;
                dt.Load(rdr);
                rdr.Close();
            }
         }
    }
