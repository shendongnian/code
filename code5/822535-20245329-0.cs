    //Get the cells of the active worksheet
    SpreadsheetGear.IRange cells = workbookView1.ActiveWorksheet.Cells;
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
