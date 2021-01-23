    if (Directory.Exists(Server.MapPath("path")))
    {
                 string filename = Path.GetFileName("path");// to get filename
     string conStr = string.Empty;
            string extension = Path.GetExtension(filename);// get extension
            if (extension == ".xls" || extension == ".xlsx")
            {
                switch (extension)
                {
                    case ".xls": //Excel 1997-2003
                        conStr = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source='" + mappingPath + "';" + "Extended Properties=Excel 8.0;";
                        break;
                    case ".xlsx": //Excel 2007
                        conStr = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source='" + mappingPath + "';" + "Extended Properties=Excel 8.0;";
                        break;
                    default:
                        break;
                }
    
                OleDbConnection connExcel = new OleDbConnection(conStr.ToString());
                OleDbCommand cmdExcel = new OleDbCommand();
                OleDbDataAdapter oda = new OleDbDataAdapter();
                connExcel.Open();
    
                DataTable dtExcelSchema;
                dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                ViewState["SheetName"] = SheetName;
                //Selecting Values from the first sheet
                //Sheet name must be as Sheet1
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT * From [" + SheetName + "]", conStr.ToString()); // to fetch data from excel 
                da.Fill(dtExcel);
                   
    }
