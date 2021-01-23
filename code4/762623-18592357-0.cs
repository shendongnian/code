    try
    {
        excelWorkbook = excelApp.Workbooks.Open(path,
        0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "",
        true, false, 0, true, false, false);
        // ... Do all your processing with excel file here
    }
    catch (Exception theException)
    {
        String errorMessage;
        errorMessage = "Error: ";
        errorMessage = String.Concat(errorMessage, theException.Message);
        errorMessage = String.Concat(errorMessage, " Line: ");
        errorMessage = String.Concat(errorMessage, theException.Source);
        MessageBox.Show(errorMessage, "Error");
    }
    finally
    {
       excelWorkbook.Close();
       excelApp.Application.Quit();
     }
