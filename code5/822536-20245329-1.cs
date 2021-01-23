    //Get the cells of a worksheet
    SpreadsheetGear.IRange cells = worksheet.Cells;
    int iColRemark = 0;
    //loop through columns
    for (int iCol = 0; iCol < cells.ColumnCount; iCol++)
    {
      //check header row for colummn that has the text 'Remark'
      if (cells[0, iCol].Text.Equals("Remark"))
      {
        iColRemark = iCol;
        break;
      }
    }
