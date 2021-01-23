    using ClosedXML.Excel;
     using (ClosedXML.Excel.XLWorkbook wb = new ClosedXML.Excel.XLWorkbook())
      {
        var ws = wb.Worksheets.Add("WorkSheetName");
        ws.Range(firstCellRow, firstCellColumn, lastCellRow, lastCellColumn).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
      }
