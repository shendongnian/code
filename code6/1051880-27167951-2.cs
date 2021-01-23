    string[] nameColumns = { "Name", "Family", "ID" };
    DataTable tblNames = table.Clone();
    var removeColumns = tblNames.Columns.Cast<DataColumn>()
        .Where(c => !nameColumns.Contains(c.ColumnName)).ToList();
    removeColumns.ForEach(c => tblNames.Columns.Remove(c));
    foreach (var x in distinctNames)
        tblNames.Rows.Add(x.Name, x.Family, x.ID);
    string[] propertyColumns = { "ID", "PropertyID", "PropertyEnergy" };
    DataTable tblProperties = table.Clone();
    removeColumns = tblProperties.Columns.Cast<DataColumn>()
        .Where(c => !propertyColumns.Contains(c.ColumnName)).ToList();
    removeColumns.ForEach(c => tblProperties.Columns.Remove(c));
    foreach (var x in distinctProperties)
        tblProperties.Rows.Add(x.ID, x.PropertyID, x.PropertyEnergy);
