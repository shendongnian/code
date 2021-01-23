    if (fi.Extension.Equals(".xls"))
    {
       _connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + 
           _filePath + " ;Extended Properties=\"Excel 8.0;HDR=No;IMEX=1\"";
    }
    else if (fi.Extension.Equals(".xlsx"))
    {
       _connectionString = "Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" + 
           _filePath + " ;Extended Properties=\"Excel 12.0;HDR=No;IMEX=1\"";
    }
