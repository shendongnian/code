    public void SaveExcelWorkBook()
    {
       OpenFileDialog openDlg = new OpenFileDialog();
       openDlg.InitialDirectory = @"C:\";
       openDlg.ShowDialog();
       string path = openDlg.FileName;
       if (openDlg.ShowDialog() == DialogResult.OK)
       {
          try
          {
             Application excelApp = new Application();
             Workbook workBook = excelApp.Workbooks.Open(path);
             Worksheet workSheet = (Worksheet)workBook.Worksheets[1];
             // Do your work here inbetween the declaration of your workbook/worksheet  
             // and the save action below.
             workBook.SaveAs(/*path to save it to*/);  // NOTE: You can use 'Save()' or 'SaveAs()'
             workBook.Close(); 
          }
          catch (Exception ex)
          {
          }
       }
    }
