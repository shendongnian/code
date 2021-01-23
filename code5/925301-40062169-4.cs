    using (TextWriter writer = new StreamWriter(@"C:\test.csv", false, System.Text.Encoding.UTF8))
    {
        var csv = new CsvWriter(writer);
        csv.WriteRecords(values); // where values implements IEnumerable
    }
