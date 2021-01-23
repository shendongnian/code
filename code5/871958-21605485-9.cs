    using(var rd  = new StreamReader(filePath))
    using (var csvReader = new CsvReader(rd, false, '\t', '\0', '\0', '#', ValueTrimmingOptions.All))
    {
        csvReader.MissingFieldAction = MissingFieldAction.ParseError;
        csvReader.DefaultParseErrorAction = ParseErrorAction.RaiseEvent;
        csvReader.ParseError += csv_ParseError;
        csvReader.SkipEmptyLines = true;
        int fieldCount = csvReader.FieldCount;
        while (csvReader.ReadNextRecord())
        {
           var fields = new List<string>();
            for (int i = 0; i < fieldCount; i++)
            {
                fields.Add(csvReader[i]);
            }
            lines.Add(fields);
        }
    }
