    DataTable FileToDataTable(string FilePath)
    {
        
        var dt = new DataTable();
        IEnumerable<string[]> lineFields = File.ReadLines(FilePath).Select(line => line.Split('|'));
        foreach (var order in lineFields)
        {
            if (order.Length < dt.Columns.Count)
                dt.Columns.AddRange(Enumerable
                    .Range(1, order.Length - dt.Columns.Count)
                    .Select(i => new DataColumn("Column " + i))
                    .ToArray());
            dt.Rows.Add(order);
        }
        return dt;
    }
