    public static DataSet Exceltotable(this string path)
    {
        using (var pck = new OfficeOpenXml.ExcelPackage())
        {
            using (var stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                pck.Load(stream);
            }
            DataSet dataSet = new DataSet();
            var wss = pck.Workbook.Worksheets;
            foreach (var ws in wss)
            {
                DataTable tbl = new DataTable();
                //Populate the datatable here
                ...
               dataSet.Tables.Add(tbl);
            }
            return dataSet;
        }
    }
