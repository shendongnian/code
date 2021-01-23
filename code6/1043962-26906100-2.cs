    DataTable FileToDataTable(string FilePath)
    {
        
        var dt = new DataTable();
        IEnumerable<string[]> lineFields = File.ReadLines(FilePath).Select(line => line.Split('|'));
        dt.Columns.AddRange(lineFields.First().Select(i => new DataColumn()).ToArray());
        foreach (var order in lineFields.Skip(1))
            dt.Rows.Add(order);
        return dt;
    }
