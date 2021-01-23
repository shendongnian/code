    string excelconString = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;IMEX=1""", filePath);
    string excelQuery = "select col1 from [Sheet1$]";
               
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    
    using (var excelConn = new OleDbConnection(excelconString))
    {
        excelConn.Open();
        using (var oda = new OleDbDataAdapter(excelQuery, excelConn))
        {
            oda.Fill(ds);
            dt = ds.Tables[0];
        }
    }
