    var sheet = workbook.GetSheetAt(0);
    var range = "E3:H8";
    var cellRange = CellRangeAddress.ValueOf(range);      
    
    for (var i = cellRange.FirstRow; i <= cellRange.LastRow; i++)
    {
      var row = sheet.GetRow(i);
      for (var j = cellRange.FirstColumn; j <= cellRange.LastColumn; j++)
      {
        // skip cell with column index 5 (column F)
        if (j == 5) continue;
        // do your work here
        Console.Write("{0}\t", row.GetCell(j));                             
      }
      
      Console.WriteLine();
    }
