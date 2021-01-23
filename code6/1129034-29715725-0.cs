    Excel.Application excel = new Excel.Application();
    excel.Visible = false;
    Excel.Workbook xlWorkbook = excel.Workbooks.Open(fileName);
    Excel.Worksheet xlWorksheet = xlWorkbook.Sheets[nameOfSheet];
    tempFileName = GetTempFile("html");
    object missing = System.Reflection.Missing.Value;
    object newFileName = (object)tempFileName;
    object fileType = (object)Excel.XlFileFormat.xlHtml;
    xlWorkbook.SaveAs(tempFileName, fileType, missing, missing, missing, missing,
          Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
          missing, missing, missing, missing, missing);
