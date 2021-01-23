        IEnumerable<Entry> ReadEntries()
        {
            CsvFileDescription inputFileDescription = new CsvFileDescription
            {
                SeparatorChar = ',',
                FirstLineHasColumnNames = true
            };
            CsvContext ctx = new CsvContext();
            return ctx.Read<Entry>("test.csv", inputFileDescription);
        }
