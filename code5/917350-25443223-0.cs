    using Excel = Microsoft.Office.Interop.Excel;
    ...
    Excel.ListObject tbl = ... // code to get the selected ListObject
    // get element value by column name and row index
    object val = ((Excel.Range)xtbl.Range.get_Item(RowInd, xtbl.ListColumns.get_Item(ColName).Index)).Value2;
    // get element by row and column index
    object val = ((Excel.Range)xtbl.Range.get_Item(RowInd, ColInd)).Value2;
    
