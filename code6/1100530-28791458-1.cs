    DataTable container= new DataTable();
    container.Columns.Add(new DataColumn("UserName", typeof(string)));
    container.Columns.Add(new DataColumn("Name", typeof(string)));
    container.Columns.Add(new DataColumn("Family", typeof(string)));
    DataRow convertedForTable = container.NewRow();
    object[] rowArray = new object[myRow.Cells.Count];
    for (int i = 0; i < myRow.Cells.Count; i++)
           rowArray[i] = myRow.Cells[i].Text;
    convertedForTable.ItemArray = rowArray;
    container.Rows.Add(convertedForTable);
