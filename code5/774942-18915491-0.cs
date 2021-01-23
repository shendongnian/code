    var a = new DataTable();
    a.Columns.Add("ID");
    a.Columns.Add("Name");
    a.Columns.Add("Company");
    a.Columns.Add("Age");
    var b = new DataTable();
    b.Columns.Add("Name");
    b.Columns.Add("Company");
    b.Columns.Add("Age");
    var destination = a.AsEnumerable();
    var localValues = b.AsEnumerable();
    var diff = destination.Join(localValues, dstRow => dstRow["Name"], srcRow => srcRow["Name"],
        (dstRow, srcRow) => 
    new {Destination = dstRow, Source = srcRow})
    .Where(combinedView =>
        combinedView.Destination["Age"] != combinedView.Source["Age"] ||
        combinedView.Destination["Company"] != combinedView.Source["Company"]);
