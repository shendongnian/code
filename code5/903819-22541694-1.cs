    //Get Selected Rows
    int[] selectedRows = DevExpress.XtraGrid.Views.Grid.GetSelectedRows();
    
    //Get the value of the cell you want. Where GridColumn is your DevXpress GridColumn Object
    DevExpress.XtraGrid.Views.Grid.GetRowCellValue(selectedRows[0], GridColumn)
    //For Entire Row
    DevExpress.XtraGrid.Views.Grid.GridView.GetRow(selectedRows[0]);
