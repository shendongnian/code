    private static void SetCursorToWaiting()
    {
       Microsoft.Office.Interop.Word.Application application = Globals.ThisAddIn.Application;
       application.System.Cursor = wdCursorWait;
    }
    private static void SetCursorToDefault()
    {
       Microsoft.Office.Interop.Word.Application application = Globals.ThisAddIn.Application;
       application.System.Cursor = wdCursorNormal;
    }
