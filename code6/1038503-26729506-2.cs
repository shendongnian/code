    private void ExportInExcel(List<ExcelData> lstData, string excelPath)
    {
        Microsoft.Office.Interop.Excel.Application xlApp;
        Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
        Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
        object misValue = System.Reflection.Missing.Value;
        xlApp = new Microsoft.Office.Interop.Excel.Application();
        xlWorkBook = xlApp.Workbooks.Add(misValue);
        xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
        xlWorkSheet.Cells[1, 1] = "Sr No.";
        xlWorkSheet.Cells[1, 2] = "Total";
        xlWorkSheet.Cells[1, 3] = "Designator";
        xlWorkSheet.Cells[1, 4] = "Comment";
        xlWorkSheet.Cells[1, 5] = "Footprint";
        xlWorkSheet.Cells[1, 6] = "Location";
        for (int i = 0; i < lstData.Count; i++)
        {
            //i+2 : in Excel file row index is starting from 1. It's not a 0 index based collection
            xlWorkSheet.Cells[i + 2, 1] = (i + 1).ToString();
            xlWorkSheet.Cells[i + 2, 2] = lstData[i].Total.ToString();
            xlWorkSheet.Cells[i + 2, 3] = String.Join(",",lstData[i].Designator.ToArray());
            xlWorkSheet.Cells[i + 2, 4] = lstData[i].Comment;
            xlWorkSheet.Cells[i + 2, 5] = lstData[i].Footprint;
            xlWorkSheet.Cells[i + 2, 6] = lstData[i].Location;
            
        }
        xlWorkBook.SaveAs(excelPath, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
        xlWorkBook.Close(true, misValue, misValue);
        xlApp.Quit();
        releaseObject(xlWorkSheet);
        releaseObject(xlWorkBook);
        releaseObject(xlApp);
    }
    //This function is created to release the excel class object.
    private void releaseObject(object obj)
    {
        try
        {
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
            obj = null;
        }
        catch (Exception ex)
        {
            obj = null;
            MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
        }
        finally
        {
            GC.Collect();
        }
    }
