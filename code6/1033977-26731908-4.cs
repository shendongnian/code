    Microsoft.Office.Tools.Excel.Workbook vstoDoc = Globals.Factory.GetVstoObject(this.Application.ActiveWorkbook);
    WorkbookEvents_BeforeSaveEventHandler handler = vstoDoc.BeforeSave;
    
    for (int i = 0; i < handler.GetInvocationList().Length; i++)
    {
      try
      {
      vstoDoc.BeforeSave -= new Microsoft.Office.Tools.Excel.SaveEventHandler(ThisDocument_BeforeSave);
      }
    catch { } //may raise exception if a handler is not attached.
    }
