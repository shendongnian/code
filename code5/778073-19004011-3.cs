    DataTable table = new DataTable();
    string[] columns = table.Columns.Cast<DataColumn>()
                                    .Select(x => x.ColumnName)
                                    .Skip(1)//skip to ignore first column
                                    .ToArray();
