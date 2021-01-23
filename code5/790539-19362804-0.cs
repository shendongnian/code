    var excel = new ExcelQueryFactory("excelFileName");
    // Only select the header row
    var headerRow = from c in excel.WorksheetRangeNoHeader("A4", "Z4")
                    select c;
    var columnNames = new List<string>();
    foreach (var headerCell in headerRow)
      columnNames.Add(headerCell.ToString());
