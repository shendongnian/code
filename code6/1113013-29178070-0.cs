    var wb = Excel.Application.ActiveWorkbook;
    List<Worksheet> sheets = new List<Worksheet();
    foreach(var sheet in wb.Sheets)
    {
       if(sheet != Excel.Application.ActiveSheet)
       {
            sheets.add(sheet);
       }
    }
