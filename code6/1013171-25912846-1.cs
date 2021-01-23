    using (IDataReader reader = someSqlCommand.ExecuteReader(…))
    {
        dynamic currentRecord = reader.AsDynamic();
        while (reader.Read())
        {
            // the magic will happen in the following two lines:
            int id = currentRecord.Id; // = reader.GetInt32(reader.GetOrdinal("Id"))
            string name = currentRecord.Name; // = reader.GetString(reader.GetOrdinal("Name"))
            …
        }
    }
