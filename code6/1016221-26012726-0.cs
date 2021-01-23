    DataTable ResultDatatable = InputDataGrid.Clone(); // creates an empty table with the same columns
    var col1Groups = InputDataGrid.AsEnumerable()
        .GroupBy(row => row.Field<string>(0));
    foreach (var group in col1Groups)
    {
        DataRow newRow = ResultDatatable.Rows.Add();
        newRow.SetField(0, group.Key);
        newRow.SetField(1, group.Sum(r => r.Field<int>(1))); // if it's not an int use int.Parse
    }
