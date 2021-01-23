    _xApp = new Excel.Application();				
    _xApp.DisplayAlerts		= false;			// don't display alerts				
    _xApp.AskToUpdateLinks	= false;			// don't present the option to ask for link updating				
    _xApp.ScreenUpdating	= false;			// turn off the redrawing the of the screen while we're working
    // open the book
    _xBook = _xApp.Workbooks.Open(Filename: _file.FullName, UpdateLinks: false, ReadOnly: true, CorruptLoad: true, Editable: false, Local: true);
    _xBook.CheckCompatibility	= false;
    _xBook.UpdateLinks	= Microsoft.Office.Interop.Excel.XlUpdateLinks.xlUpdateLinksNever;
    _xBook.Activate();
    _sheets = _xBook.Worksheets;
    // get the sheet we want
    if (!string.IsNullOrEmpty(this.WorksheetName))
    {
        for (int i = 1; i < _sheets.Count + 1; i++)
        {
            _xSheet = _sheets[i] as Excel.Worksheet;
            if (base.CheckFilter(this.WorksheetName, _xSheet.Name))
                break;
            if (_xSheet.Name.IndexOf(this.WorksheetName, StringComparison.InvariantCultureIgnoreCase) > -1)
                break;
         }
     }
     else
     {
         _xSheet = _sheets[1] as Excel.Worksheet;
     }
     if (_xSheet == null)
         throw new ArgumentException("Worksheet not found in Excel Spreadsheet provided!", "this.WorksheetName");
     _xSheet.Activate();
