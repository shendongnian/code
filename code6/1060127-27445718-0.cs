    public DataTable SpecialDistinct(DataTable table, 
        IList<string> uniqueFields, IList<string> otherFields)
    {
        // create a table for results
        var resultTable = table.Clone();
        var view = new DataView(table);
        var distinctTable = view.ToTable(true, uniqueFields.ToArray());
        foreach (DataRow distictRow in distinctTable.Rows)
        {
            var row = resultTable.NewRow();
            foreach (var uniqueField in uniqueFields)
            {
                row[uniqueField] = distictRow[uniqueField];
            }
            IEnumerable<DataRow> selectedRows = table.AsEnumerable().Where(
                r => uniqueFields.All(
                uniqueField => r[uniqueField].Equals(distictRow[uniqueField])));
            foreach (var otherField in otherFields)
            {
                var selectedRow = selectedRows.FirstOrDefault(
                    r => r[otherField] != DBNull.Value);
                if (selectedRow != null)
                    row[otherField] = selectedRow[otherField];
            }
            resultTable.Rows.Add(row);
        }
        return resultTable;
    }
