    using (IDataReader reader = simpleSelectCommand.ExecuteReader())
    {
        while (reader.Read())
        {
            myWriter.WriteStartElement("PARTNER");
            // write subnodes for this record
            myWriter.WriteEndElement();
        }
    }
