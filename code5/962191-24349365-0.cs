    FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read);
    Excel.ExcelBinaryReader reader = Excel.ExcelReaderFactory.CreateBinaryReader(fs) as Excel.ExcelBinaryReader;
    reader.IsFirstRowAsColumnNames = true;
    
    DataSet ds = reader.AsDataSet();
    foreach (DataRow dr in ds.Tables[0].Rows)
    {
        ;
    }
