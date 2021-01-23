    Excel.Application xlApp = null;
    Excel.Workbook xlWorkBook = null;
    Excel.Workbooks xlWorkBooks = null;
    Excel.Worksheet xlWorkSheet = null;
    object misValue = System.Reflection.Missing.Value;
    try
    {
        xlApp = new Excel.Application();
        xlWorkBooks = xlApp.Workbooks;
        xlWorkBook = xlWorkBooks.Add(Properties.Settings.Default.FileToSend);
        xlWorkSheet = xlWorkBook.Sheets[1];
        xlWorkSheet.EnablePivotTable = true; 
        string filename = System.IO.Path.GetTempFileName();
        xlWorkSheet.ChartObjects("Chart 1").Chart.Export(filename + ".gif");
        xlWorkBook.Close(false, misValue, misValue);
        xlApp.Quit();
    }
    catch(Exception ex)
    {
        // handle error...
    }
    finally
    {
        if (xlWorkSheet != null)
            Marshal.ReleaseComObject(xlWorkSheet);
        if (xlWorkBook != null)
            Marshal.ReleaseComObject(xlWorkBook);
        if (xlWorkBooks != null)
            Marshal.ReleaseComObject(xlWorkBooks);
        if (xlApp != null)
            Marshal.ReleaseComObject(xlApp);
    }
