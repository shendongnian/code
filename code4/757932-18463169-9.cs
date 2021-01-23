    DataTable newTable = dt.AsEnumerable()
        .GroupBy(row => row.Field<int>("ITEM"))
        .Select(g => 
        {
            DataRow first = g.First();
            if (g.Count() > 1)
            {
                int sum = g.Sum(r => r.Field<int>("QTY"));
                first.SetField("QTY", sum);
            }
            return first;
        })
        .CopyToDataTable();
