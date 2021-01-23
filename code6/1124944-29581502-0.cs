    class WorkbookAdapter : IWorkbookAdapter
    {
        private Excel.Workbook _workbook;
        public WorkbookAdapter(Excel.Workbook workbook)
        {
            _workbook = workbook;
        }
        public IEnumerable<ISheetAdapter> Worksheets
        {
            get
            {
                return this._workbook.Sheets
                    .Select(sheet => new SheetAdapter(sheet))
                    .Cast<ISheetAdapter>();
            }
        }
    }
