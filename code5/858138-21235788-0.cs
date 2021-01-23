    var sheet = workbook.GetSheetAt(0); // assuming 0 is the worksheet index
    for (var i = 0; i <= sheet.LastRowNum; i++)
    {
      var row = sheet.GetRow(i);
      if (row == null) continue;
      // do your work here
      Console.Write("{0}\t", row.GetCell(4));
      Console.Write("{0}\t", row.GetCell(6));
      Console.Write("{0}\t", row.GetCell(7));
      Console.WriteLine();
    }
