    /// <summary>
    /// Manipulate an excel file using the EPPlus API, free from http://epplus.codeplex.com/
    /// License terms (Public) on http://epplus.codeplex.com/license
    /// 
    /// </summary>
    public class ExcelWriter : IDisposable
    {
        ExcelPackage _pck;
        /// <summary>
        /// Open a new or existing file for editing.
        /// </summary>
        /// <param name="fileName"></param>
        public ExcelWriter(string fileName)
        {
            _pck = new ExcelPackage(new FileInfo(fileName));
        }
        /// <summary>
        /// Open a new or existing file for editing, and add a new worksheet with the data
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="newWorksheetName">new sheet to add</param>
        /// <param name="dtData">data to add</param>
        public ExcelWriter(string fileName, string newWorksheetName, DataTable dtData):this(fileName)
        {
            var ws = this.AddWorksheet(newWorksheetName);
            this.SetValues(ws, dtData);
        }
        /// <summary>
        /// Add a new worksheet.  Names must be unique.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ExcelWorksheet AddWorksheet(string name)
        {
            return _pck.Workbook.Worksheets.Add(name);
        }
        /// <summary>
        /// Add a new picture.  Names must be unique.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="imageName"></param>
        /// <param name="ws"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        public ExcelPicture AddPicture(Image image, string imageName, ExcelWorksheet ws, int row, int col)
        {
            var pic = ws.Drawings.AddPicture(imageName, image);
            pic.SetPosition(row, 0, col, 0);
            pic.Border.LineStyle = eLineStyle.Solid;
            return pic;
        }
        /// <summary>
        /// Note: this will only perform as well as 'SetValues' if you load/write data from left to right, top to bottom.  Otherwise it may perform poorly.
        /// </summary>
        /// <param name="ws"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="value"></param>
        public void SetValue(ExcelWorksheet ws, int row, int col, object value)
        {
            ws.Cells[row, col].Value = value;
        }
        /// <summary>
        /// Populate a large number of cells at once
        /// </summary>
        /// <param name="ws"></param>
        /// <param name="value">Data to load</param>
        public void SetValues(ExcelWorksheet ws, List<object[]> value)
        {
            ws.Cells.LoadFromArrays(value);
        }
        /// <summary>
        /// Populate a large number of cells at once
        /// </summary>
        /// <param name="ws"></param>
        /// <param name="value">Data to load</param>
        public void SetValues(ExcelWorksheet ws, DataTable dt)
        {
            ws.Cells.LoadFromDataTable(dt, true);
        }
        public void SetDefaultRowHeight(ExcelWorksheet ws, int rowHeight)
        {
            ws.DefaultRowHeight = rowHeight;
        }
        /// <summary>
        /// Saves to file and dispos
        /// </summary>
        public void Save()
        {
            _pck.Save();
        }
        /// <summary>
        /// Release all resources
        /// </summary>
        public void Dispose()
        {
            if (_pck != null)
                _pck.Dispose();
        }
    }   // class
