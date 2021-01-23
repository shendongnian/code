    using (var stream = File.Open(originalFileName, FileMode.Open, FileAccess.Read))
    {
        IExcelDataReader reader;
        
        // Create Reader - old until 3.4+
        ////var file = new FileInfo(originalFileName);
        ////if (file.Extension.Equals(".xls"))
        ////    reader = ExcelDataReader.ExcelReaderFactory.CreateBinaryReader(stream);
        ////else if (file.Extension.Equals(".xlsx"))
        ////    reader = ExcelDataReader.ExcelReaderFactory.CreateOpenXmlReader(stream);
        ////else
        ////    throw new Exception("Invalid FileName");
        // Or in 3.4+ you can only call this:
        reader = ExcelDataReader.ExcelReaderFactory.CreateReader(stream)
        //// reader.IsFirstRowAsColumnNames
        var conf = new ExcelDataSetConfiguration
        {
            ConfigureDataTable = _ => new ExcelDataTableConfiguration
            {
                UseHeaderRow = true 
            }
        };
        var dataSet = reader.AsDataSet(conf);
        // Now you can get data from each sheet by its index or its "name"
        var dataTable = dataSet.Tables[0];
        
        //...
    }
