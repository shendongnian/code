    using Excel;
    
    [HttpPost]
    public ActionResult ShowExcelFile(HttpPostedFileBase getFile)
    {
        if (getFile != null && getFile.ContentLength > 0)
        {
            // .xlsx
            IExcelDataReader reader = ExcelReaderFactory.CreateOpenXmlReader(getFile.InputStream);
            
            // .xls
            IExcelDataReader reader = ExcelReaderFactory.CreateBinaryReader(getFile.InputStream);
            
            reader.IsFirstRowAsColumnNames = true; // if your first row contains column names
        }
    
        return PartialView("ShowExcelFile");
    }
