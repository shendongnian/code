    DataTable FileToDataTable1(string FilePath)
    {
        var dt = new DataTable();
        using (var st = new StreamReader(FilePath))
            while (st.Peek() >= 0)
            {
                var order = st.ReadLine().Split('|');
                if (order.Length < dt.Columns.Count)
                    dt.Columns.AddRange(Enumerable
                        .Range(1, order.Length - dt.Columns.Count)
                        .Select(i => new DataColumn("Column " + i))
                        .ToArray());
                dt.Rows.Add(order);
            }
        return dt;
    }
