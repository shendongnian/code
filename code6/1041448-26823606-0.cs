        static void ConvertXlsToXlsx(string xlsFilePath, string xlsxFilePath)
        {
            Microsoft.Office.Interop.Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = false;
            Microsoft.Office.Interop.Excel.Workbook eWorkbook = excelApp.Workbooks.Open(xlsFilePath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            eWorkbook.SaveAs(xlsxFilePath, Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            eWorkbook.Close(false, Type.Missing, Type.Missing);
        }
