    tableA.PrimaryKey = primaryKeyColumnNames.Select(x => tableA.Columns[x]).ToArray();
    tableB.PrimaryKey = primaryKeyColumnNames.Select(x => tableB.Columns[x]).ToArray();
    var matches = (from System.Data.DataRow RowA in tableA.Rows
                    where tableB.Rows.Contains(RowA.ItemArray.Where((x,y) => primaryKeyColumnNames.Contains(tableA.Columns[y].ColumnName)).ToArray())
                    select RowA).ToList();
