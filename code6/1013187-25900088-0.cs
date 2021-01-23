    while (reader.Read())
    {
        if(rdr.IsDBNull(0) || rdr.IsDBNull(1) || rdr.IsDBNull(2) || rdr.IsDBNull(3))
        {
            // e.Source = "N/A";
        }
        else 
        {
            string originalfilename = reader.GetString(0);
            string renamedfilename = (string)reader[1];
            string sheet = (string)reader[2];
            string version = (string)reader[3];
            AddDocument(originalfilename, renamedfilename, sheet, version);
        }
    }
