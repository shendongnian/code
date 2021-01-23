    var allZeroTables = dsPriorities.Tables.Cast<DataTable>()
        .Where(tbl => tbl.AsEnumerable()
            .All(r => tbl.Columns.Cast<DataColumn>()
                .All(c => r.Field<string>(c) == "0")));
    foreach (DataTable zeroTable in allZeroTables.ToList())
        dsPriorities.Tables.Remove(zeroTable);
