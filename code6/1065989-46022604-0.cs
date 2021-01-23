    var file = new FileInfo(originalFileName);
    using (
        var stream = File.Open(originalFileName, FileMode.Open, FileAccess.Read))
    {
        IExcelDataReader reader;
        if (file.Extension.Equals(".xls"))
            reader = ExcelDataReader.ExcelReaderFactory.CreateBinaryReader(stream);
        else if (file.Extension.Equals(".xlsx"))
            reader = ExcelDataReader.ExcelReaderFactory.CreateOpenXmlReader(stream);
        else
            throw new Exception("Invalid FileName");
        //// reader.IsFirstRowAsColumnNames
        var conf = new ExcelDataSetConfiguration
        {
            ConfigureDataTable = _ => new ExcelDataTableConfiguration
            {
                UseHeaderRow = true 
            }
        };
        var dataSet = reader.AsDataSet(conf);
        var dataTable = dataSet.Tables[0];
        
        //...
    }
