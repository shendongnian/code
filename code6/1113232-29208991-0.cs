    //insert rows below a range from the cell going table rows down
    ws.Range(
        cell.Address.RowNumber
        , cell.Address.ColumnNumber
        , cell.Address.RowNumber + DocDataSet.Tables[tableNo].Rows.Count
        , cell.Address.ColumnNumber)
        .InsertRowsBelow(DocDataSet.Tables[tableNo].Rows.Count);
    
    //InsertData returns a range covering the inserted data
    var ra = ws.Cell(cell.Address.RowNumber, cell.Address.ColumnNumber)
        .InsertData(DocDataSet.Tables[tableNo].AsEnumerable());
    
    //apply the style of the table token cell to the whole range
    ra.Style = cell.Style;
