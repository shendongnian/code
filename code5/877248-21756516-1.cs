    var aggrTable = table.Clone(); // schema only
    var groups = table.AsEnumerable()
        .GroupBy(r => new { ItemNumber = r.Field<int>("ItemNumber"), Cat1 = r.Field<string>("Cat1") });
    foreach(var group in groups)
    {
        DataRow row = aggrTable.Rows.Add();
        row.SetField("ItemNumber", group.Key.ItemNumber);
        row.SetField("Cat1", group.Key.Cat1);
        row.SetField("Low Price", group.Min(r => r.Field<int>("Low Price")));
        row.SetField("High Price", group.Max(r => r.Field<int>("High Price")));
    }
