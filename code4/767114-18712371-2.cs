    MathematicaAPI.XlHelper.CloseExcel((Worksheet)activeSheet, (Workbook)wrkbook.Resource , (Workbooks)wrkbooks.Resource);
    public static void CloseExcel(Worksheet activeSheet, Workbook wrkbook, Workbooks wrkbooks)
    {
        //http://support.microsoft.com/kb/317109 -> excel just wont close for some reason
        if (activeSheet != null)
        {
            Marshal.FinalReleaseComObject(activeSheet);
            activeSheet = null;
        }
        if (wrkbook != null)
        {
            wrkbook.Saved = true;
            wrkbook.Close(Microsoft.Office.Interop.Excel.XlSaveAction.xlDoNotSaveChanges);
        }
        if (wrkbooks != null)
        {
            wrkbooks.Close();
        }
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }
