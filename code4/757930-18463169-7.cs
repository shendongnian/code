    DataTable newTable = dt.Clone();
    var itemGroups = dt.AsEnumerable()
        .GroupBy(row => row.Field<int>("ITEM"));
    foreach (var group in itemGroups)
    {
        DataRow first = group.First();
        if (group.Count() == 1)
            newTable.ImportRow(group.First());
        else
        {
            DataRow clone = newTable.Rows.Add((object[])first.ItemArray.Clone());
            int qtySum = group.Sum(r => r.Field<int>("QTY"));
            clone.SetField("QTY", qtySum);
        }
    }
