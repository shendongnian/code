    private async void OnExitedEvent(object sender, EventArgs e)
    {
    	try
    	{
    		DisposableExited.Dispose();
    		using (SpreadsheetDocument s = SpreadsheetDocument.Open(SelectedWorkbookDictionaryImport.FilePath, false))
    		{
    			foreach (Sheet workbookSheet in s.WorkbookPart.Workbook.Sheets)
    			{
    				if (WorkbookDictionaryImports.OfType<WorkbookDictionary>().FirstOrDefault(d => d.ExcelName.Equals(SelectedWorkbookDictionaryImport.ExcelName)) is WorkbookDictionary workbookDictionary)
    				{
    					if (workbookDictionary.WorksheetDictionaryItems.OfType<WorksheetDictionary>().FirstOrDefault(d => d.Id.Equals(workbookSheet.Id)) == null)
    					{
    						Application.Current.Dispatcher.Invoke(() =>
    						{
    							WorksheetDictionary worksheetDictionary = new WorksheetDictionary()
    							{
    								WorksheetDictionaryId = Guid.NewGuid().ToString(),
    								IsSelected = false,
    								Id = workbookSheet.Id,
    								SheetId = workbookSheet.SheetId,
    								Name = workbookSheet.Name,
    								Header = workbookSheet.Name,
    								HeaderInfo = GetSheetStateValues(workbookSheet.State),
    								Code = GetSheetCodeValues(workbookSheet.Name.ToString()).ToString(),
    								Description = BeforeWorkbookDictionary.Subject,
    								WorkbookDictionary = BeforeWorkbookDictionary
    							};
    							workbookDictionary.WorksheetDictionaryItems.Add(worksheetDictionary);
    						});
    					}
    				}
    			}
    		}
    	}
    	catch (Exception msg)
    	{
    	...
    	..
    	.
    	}
    	finally
    	{
    		if (ProgressController != null)
    		{
    			await ProgressController.CloseAsync();
    			ProgressController = default(ProgressDialogController);
    		}
    	}
    }
