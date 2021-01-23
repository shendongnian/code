    private async void OnOpenWorkSheetImportCommand(object sender, ExecutedRoutedEventArgs e)
    {
    	try
    	{
    		if (e.Parameter is IWorkSheetImportViewModel model)
    		{
    			if (WorksheetDictionaries.OfType<WorksheetDictionary>().FirstOrDefault(a => a.Header.Equals(model.Header)) is WorksheetDictionary worksheetDictionary)
    			{
    				Type officeType = Type.GetTypeFromProgID("Excel.Application", true);
    
    				if (officeType != null)
    				{
    					BeforeWorkbookDictionary = worksheetDictionary.WorkbookDictionary;
    					OpenInteropWorkbookDictionary(worksheetDictionary.WorkbookDictionary, worksheetDictionary, true);
    				}
    				else
    				{
    					throw new ArgumentException("Microsoft Excel is not installed!");
    				}
    			}
    		}
    	}
    	...
    	..
    	.
    }
