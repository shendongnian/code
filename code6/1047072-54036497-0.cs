    static void Main(string[] args)
    {
        Excel.Application excelApp;
    
        string sourceFileName = "Original.xlsx"; //Source excel file
        string tempFileName = "temp.xlsx";
    
        string folderPath = @"C:\FodlerPath\";
    
        string sourceFilePath = System.IO.Path.Combine(folderPath, sourceFileName);
        string destinationFilePath = System.IO.Path.Combine(folderPath, tempFileName);
    
        System.IO.File.Copy(sourceFilePath,destinationFilePath,true);
    
        /************************************************************************************/
    
        excelApp = new Excel.Application();
        Excel.Workbook wbSource, wbTarget;
        Excel.Worksheet currentSheet;
    
        wbSource = excelApp.Workbooks.Open(sourceFilePath);
        wbTarget = excelApp.Workbooks.Open(destinationFilePath); 
        
        currentSheet = wbSource.Worksheets["Sheet1"]; //Sheet which you want to copy
        currentSheet.Name = "TempSheet"; //Give a name to destination sheet
    
        currentSheet.Copy(wbTarget.Worksheets[1]); //Actual copy
        wbSource.Close(false);
        wbTarget.Close(true);
        excelApp.Quit();
    
        System.IO.File.Delete(sourceFilePath);
        System.IO.File.Move(destinationFilePath, sourceFilePath);
    }
