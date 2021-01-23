    public void SaveExcelWorkBook()
    {
       try
       {
          Application excelApp = new Application();
          Workbook workBook = excelApp.Workbooks.Open(path to your workbook);
          Worksheet workSheet = (Worksheet)workBook.Worksheets[1];
          Range range = workSheet.get_Range("A1");
          range.Columns.ColumnWidth = 22.34;
          range = workSheet.get_Range("B1");
          range.Columns.ColumnWidth = 22.34;
          workSheet.get_Range("A1", "B1").Font.Bold = true;
          workBook.SaveAs(path to save it to);  // NOTE: You can use 'Save()' or 'SaveAs()' here.
          workBook.Close();
        }
        catch (Exception ex)
        {
        }
    }
