    Aspose.Cells.LoadOptions options = new Aspose.Cells.LoadOptions(Aspose.Cells.LoadFormat.CSV);
    
    options.ConvertNumericData = false;
                            
    Workbook workBook = new Workbook("C:\\Data\\open.csv", options);
    workBook.Settings.CheckExcelRestriction = false;
    var workSheet = workBook.Worksheets[workBook.Worksheets.ActiveSheetIndex];
    
    Console.WriteLine( workSheet.Cells[0, 0].Value.ToString());  
    Console.WriteLine( workSheet.Cells[0, 1].Value.ToString());
    Console.WriteLine( workSheet.Cells[0, 2].Value.ToString());
    Console.WriteLine( workSheet.Cells[0, 3].Value.ToString());
    
    Console.WriteLine( workSheet.Cells[1, 0].Value.ToString());  
    Console.WriteLine( workSheet.Cells[1, 1].Value.ToString());
    Console.WriteLine( workSheet.Cells[1, 2].Value.ToString());
    Console.WriteLine( workSheet.Cells[1, 3].Value.ToString());
