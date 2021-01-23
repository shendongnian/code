    DataTable stringDataTable = intDataTable.Clone();
               stringDataTable.Columns[0].DataType = typeof(string);
               stringDataTable.Columns[1].DataType = typeof(string);
                foreach (DataRow dr in intDataTable.Rows)
                {
                    stringDataTable.ImportRow(dr);
                }
    treeView1.LoadFromDataTable(stringDataTable);
