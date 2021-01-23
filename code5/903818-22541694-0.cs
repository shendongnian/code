    //Get Selected Rows
    int[] selectedRows = DevExpressGridView.GetSelectedRows();
    
    //Get the value of the cell you want. Where GridColumn is your DevXpress GridColumn Object
    DevExpressGridView.GetRowCellValue(selectedRows[0], GridColumn)
    //For Entire Row
    DevExpressGridView.GetRow(selectedRows[0]);
