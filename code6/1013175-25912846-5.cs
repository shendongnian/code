    using (IDataReader reader = someSqlCommand.ExecuteReader(…))
    {
        dynamic current = reader.AsDynamic(); // façade representing the current record
        while (reader.Read())
        {
            // the magic will happen in the following two lines:
            int id = current.Id; // = reader.GetInt32(reader.GetOrdinal("Id"))
            string name = current.Name; // = reader.GetString(reader.GetOrdinal("Name"))
            …
        }
    }
