    while (reader.Read())
    {
        try
        {
            string originalfilename = GetValueOrDefault<string>(reader[0], "N/A");
            string renamedfilename = GetValueOrDefault<string>(reader[1], "N/A");
            string sheet = GetValueOrDefault<string>(reader[2], "N/A");
            string version = GetValueOrDefault<string>(reader[3], "N/A");
    
            AddDocument(originalfilename, renamedfilename, sheet, version);
        }
        catch (InvalidCastException e)
        {
            e.Source = "N/A";
        }
    }
