    using (StreamReader sr = new StreamReader("data.csv"))
    {
        var reader = new CsvReader<Record>(sr, parseMidQuotes: true, readHeader: false);
        while (reader.Read())
        {
            Record rec = reader.CurrentObject.Value;
            rec.Description = rec.Description.Replace("\\\"", "\"");
            // use record...
        }
    }
