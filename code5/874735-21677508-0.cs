    var allZeroTAbles = dsPriorities.Tables.Cast<DataTable>()
        .Where(tbl => tbl.AsEnumerable()
            .All(r => tbl.Columns.Cast<DataColumn>()
                .All(c => r.Field<string>(c) == "0")));
    foreach (DataTable zeroTable in allZeroTAbles)
        dsPriorities.Tables.Remove(zeroTable);
