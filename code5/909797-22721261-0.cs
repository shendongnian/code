    using (SqlDataReader reader = cmd.ExecuteReader())
    {
        while (reader.Read())
        {
            try { if (!reader.IsDBNull(0)) { tempList.Add(reader[0].ToString()); } }
            catch { }
        }
    }
