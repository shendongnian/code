    foreach (DataRow row in rows)
    {
        var cell = ws.Cells[rowIndex, colIndex];
        
        // Setting Value in cell
        // Replace the '..' with an index, which is the index or the name of the column you are 
        // trying to get the value from.
        cell.Value = Convert.ToInt32(row[..]);
        //Setting borders of cell
        var border = cell.Style.Border;
        border.Left.Style =
        border.Right.Style = ExcelBorderStyle.Thin;
        colIndex++;
    }
