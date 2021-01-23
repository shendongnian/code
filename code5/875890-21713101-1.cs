    private void DoWork(string fileName, Func<string[], object> fieldParser)
    {
        using (var parser = new TextFieldParser(fileName))
        {
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");
            while (!parser.EndOfData)
            {
                string[] fields = parser.ReadFields();
                context.Table1.AddOrUpdate(c => c.Col1, fieldParser(fields));
            }
        }
    }
