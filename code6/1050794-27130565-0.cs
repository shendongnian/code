    var nameGroups = dtMain.AsEnumerable().GroupBy(row => row.Field<string>("Name"));
    foreach (var nameGroup in nameGroups)
    {
        bool isFirstRow = true;
        foreach (DataRow row in nameGroup)
        {
            DataRow newRow = dtFinal.Rows.Add();
            newRow.SetField("Name", isFirstRow ? nameGroup.Key : "");
            newRow.SetField("Plot", row.Field<string>("Plot"));
            newRow.SetField("Area", row.Field<string>("Area"));
            isFirstRow = false;
        }              
    }
