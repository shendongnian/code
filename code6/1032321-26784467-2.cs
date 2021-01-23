    public void openExcelTemplateFromResources ()
    {
        string tempPath = System.IO.Path.GetTempFileName(); 
        System.IO.File.WriteAllBytes(tempPath, Properties.Resources.excelResource);
        Excel.Application excelApplication = new Excel.Application();
        Excel._Workbook excelWorkbook;
        excelWorkbook = excelApplication.Workbooks.Open(tempPath)
    
        excelApplication.Visible = true; // at this point its up to the user to save the file
    }
