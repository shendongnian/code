    tableA.PrimaryKey = primaryKeyColumnNames.Select(x => new System.Data.DataColumn(x)).ToArray();
    tableB.PrimaryKey = tableA.PrimaryKey;
    var query = (from System.Data.DataRow RowA in tableA.Rows
                    where tableB.Rows.Contains(RowA.ItemArray)
                    select RowA);
