    private void OpenInteropWorkbookDictionary(WorkbookDictionary workbookDictionary, WorksheetDictionary worksheetDictionary, bool activateWorksheet = false)
    {
    	if (ExcelApplication != null && ExcelApplication.Visible == true)
    	{
    		ExcelApplication.ActiveWindow.Activate();
    		IntPtr handler = FindWindow(null, ExcelApplication.Caption);
    		SetForegroundWindow(handler);
    	}
    	else
    	{
    		if (ExcelApplication != null) Marshal.FinalReleaseComObject(ExcelApplication);
    		if (ExcelWorkbook != null) Marshal.FinalReleaseComObject(ExcelWorkbook);
    		if (ExcelWorksheet != null) Marshal.FinalReleaseComObject(ExcelWorksheet);
    		if (ExcelWorksheets != null) Marshal.FinalReleaseComObject(ExcelWorksheets);
    
    		ExcelApplication = new Microsoft.Office.Interop.Excel.Application
    		{
    			// if you want to make excel visible to user, set this property to true, false by default
    			Visible = true,
    			WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlMaximized
    		};
    
    		ExcelApplication.WindowActivate += new Microsoft.Office.Interop.Excel.AppEvents_WindowActivateEventHandler(OnWindowActivate);
    		ExcelApplication.WindowDeactivate += new Microsoft.Office.Interop.Excel.AppEvents_WindowDeactivateEventHandler(OnWindowDeactivate);
    
    		ExcelApplication.WorkbookOpen += new Microsoft.Office.Interop.Excel.AppEvents_WorkbookOpenEventHandler(OnWorkbookOpen);
    		ExcelApplication.WorkbookActivate += new Microsoft.Office.Interop.Excel.AppEvents_WorkbookActivateEventHandler(OnWorkbookActivate);
    		ExcelApplication.WorkbookDeactivate += new Microsoft.Office.Interop.Excel.AppEvents_WorkbookDeactivateEventHandler(OnWorkbookDeactivate);
    
    		// open an existing workbook
    		ExcelWorkbook = ExcelApplication.Workbooks.Open(BeforeWorkbookDictionary.FilePath, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
    		ExcelWorkbook.BeforeClose += new Microsoft.Office.Interop.Excel.WorkbookEvents_BeforeCloseEventHandler(OnBeforeClose);
    		ExcelWorkbook.AfterSave += new Microsoft.Office.Interop.Excel.WorkbookEvents_AfterSaveEventHandler(OnAfterSave);
    		ExcelWorkbook.BeforeSave += new Microsoft.Office.Interop.Excel.WorkbookEvents_BeforeSaveEventHandler(OnBeforeSave);
    
    		// SheetEvents
    		ExcelWorkbook.SheetChange += new Microsoft.Office.Interop.Excel.WorkbookEvents_SheetChangeEventHandler(OnSheetChange);
    		ExcelWorkbook.SheetSelectionChange += new Microsoft.Office.Interop.Excel.WorkbookEvents_SheetSelectionChangeEventHandler(OnSheetSelectionChange);
    		ExcelWorkbook.NewSheet += new Microsoft.Office.Interop.Excel.WorkbookEvents_NewSheetEventHandler(OnNewSheet);
    		ExcelWorkbook.SheetBeforeDelete += new Microsoft.Office.Interop.Excel.WorkbookEvents_SheetBeforeDeleteEventHandler(OnSheetBeforeDelete);
    		ExcelWorkbook.SheetActivate += new Microsoft.Office.Interop.Excel.WorkbookEvents_SheetActivateEventHandler(OnSheetActivate);
    		ExcelWorkbook.SheetDeactivate += new Microsoft.Office.Interop.Excel.WorkbookEvents_SheetDeactivateEventHandler(OnSheetDeactivate);
    
    		//// get all sheets in workbook
    		ExcelWorksheets = ExcelWorkbook.Worksheets;
    	}
    
    	if (activateWorksheet)
    	{
    		ExcelWorksheet = ExcelWorkbook.Sheets[worksheetDictionary.Name];
    		ExcelWorksheet.Activate();
    	}
    }
