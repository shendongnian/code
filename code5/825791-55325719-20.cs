    private async void OnWorkbookDeactivate(Microsoft.Office.Interop.Excel.Workbook Wb)
    {
    	try
    	{
    		ProgressController = default(ProgressDialogController);
    		if (ExcelApplication != null && ExcelApplication.Visible == true)
    		{
    			int excelProcessId = -1;
    			GetWindowThreadProcessId(new IntPtr(ExcelApplication.Hwnd), ref excelProcessId);
    			Process ExcelProc = Process.GetProcessById(excelProcessId);
    
    			if (ExcelProc != null)
    			{
    			    ExitedEventArgs = Observable.FromEventPattern<object, EventArgs>(ExcelProc, MethodParameter.Exited);
    			    DisposableExited = ExitedEventArgs.Subscribe(evt => OnExitedEvent(evt.Sender, evt.EventArgs));
    			    ExcelProc.EnableRaisingEvents = true;
    				ProgressController = await _dialogCoordinator.ShowProgressAsync(this, string.Format("Workbook {0}", BeforeWorkbookDictionary.ExcelName), "Please wait! Processing any changes...");
    				ProgressController.SetIndeterminate();
    
    				ExcelApplication.Quit();
    
    				if (ExcelApplication != null) Marshal.FinalReleaseComObject(ExcelApplication);
    				if (ExcelWorkbook != null) Marshal.FinalReleaseComObject(ExcelWorkbook);
    				if (ExcelWorksheet != null) Marshal.FinalReleaseComObject(ExcelWorksheet);
    				if (ExcelWorksheets != null) Marshal.FinalReleaseComObject(ExcelWorksheets);
    
    				ExcelApplication = null;
    				ExcelWorkbook = null;
    				ExcelWorksheet = null;
    				ExcelWorksheets = null;
    
    				ExcelProc.WaitForExit();
    				ExcelProc.Refresh();
    			}
    		}
    	}
    	catch (Exception msg)
    	{
    	...
    	..
    	.
    	}
    }
