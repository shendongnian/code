    var arrayNames = (from DataColumn x in stationTable.Columns
                              where !x.ColumnName.Contains("B_")  // note the reversal
                              select x.ColumnName).ToArray();
    DataView dv = new DataView(stationTable);
    foreach (string colName in arrayNames)    
        dv.Table.Columns[colName].ColumnMapping = MappingType.Hidden
