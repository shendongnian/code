    var locationNames = Model.SelectMany(n => n.Inventory).Select(n => n.Location.Name).Distinct().ToArray();
    foreach(var locationName in locationNames)
    {
        var columnName = locationName;
        columns.Add(m => m.Inventory.Single(n => n.Location.Name == columnName).Quantity, columnName).Titled(columnName);
    }
