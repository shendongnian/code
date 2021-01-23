    public void openExcelTemplateFromResources ()
    {
        string excelTemplateFromResources = System.IO.Path.GetTempFileName(); 
        System.IO.File.WriteAllBytes(excelTemplateFromResources.Properties.Resources.excelResource); 
        Excel.Application excelApplication = new Excel.Application();
        Excel._Workbook excelWorkbook;
        excelWorkbook = excelApplication.Workbooks.Open(excelTemplateFromResources)
    
        excelApplication.Visible = true; // at this point its up to the user to save the file
    }
