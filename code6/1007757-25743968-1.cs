    FileInfo newFile = new FileInfo(@"C:\Reports\excel.xls");
    if (newFile.Exists)
    {
        newFile.Delete();  // ensures we create a new workbook
        newFile = new FileInfo(@"C:\Reports\excel.xls");
    }
  
    using (ExcelPackage pck = new ExcelPackage(newFile))
    {
         ExcelWorksheet ws = pck.Workbook.Worksheets.Add(reportName);
         ws.Cells["A1"].LoadFromDataTable(DT, true);
         pck.Save();
    }
