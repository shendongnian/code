    while (reader.Read())
    {
        string originalfilename = reader.GetString(0);
        string renamedfilename = (string)reader[1];
        string sheet = rdr.IsDBNull(2) ? "N/A" : reader.GetString(2);;
        string version = (string)reader[3];
        AddDocument(originalfilename, renamedfilename, sheet, version);
    }
