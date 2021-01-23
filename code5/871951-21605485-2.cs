    using (CsvReader csvReader = new CsvReader(new StreamReader(filePath), false, '\t', '"', '"', '#', LumenWorks.Framework.IO.Csv.ValueTrimmingOptions.All))
    {
        int fieldCount = csvReader.FieldCount;
        while (csvReader.ReadNextRecord())
        {
            for (int i = 0; i < fieldCount; i++)
                Console.WriteLine("Column {0}: {1}", i + 1, csvReader[i]);
        }
    }
