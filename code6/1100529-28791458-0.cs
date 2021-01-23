    DataTable container = new DataTable(); 
    DataRow convertedForTable = container.NewRow();
    object[] rowArray = new object[myRow.Cells.Count];
    for (int i = 0; i < myRow.Cells.Count; i++)
         {
                rowArray[i] = myRow.Cells[i].Text;
         }
    convertedForTable.ItemArray = rowArray;
