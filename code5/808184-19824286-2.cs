    public void SaveExcelWorkBook()
    {
       try
       {
          Application excelApp = new Application();
          Workbook workBook = excelApp.Workbooks.Open(path to your workbook);
          Worksheet workSheet = (Worksheet)workBook.Worksheets[1];
          // Do your work here inbetween the declaration of your workbook/worksheet  
          // and the save action below.
          
          workBook.SaveAs(path to save it to);  // NOTE: You can use 'Save()' or 'SaveAs()'
          workBook.Close(); 
        }
        catch (Exception ex)
        {
        }
    }
