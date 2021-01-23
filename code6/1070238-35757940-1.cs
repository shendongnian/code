    //Get Range like A4:M30
    
        public string GetRange(string SheetName, string excelConnectionString)
       {
            string rangeInput = "",rangeColName="";
            int columnsCount = 0;
            int rowStartRange = 0;
            
            columnsCount = GetNumberOfColumnsInSheet(SheetName, excelConnectionString);
            rowStartRange = GetStartRowRange(SheetName, excelConnectionString); // This is optional if you want always A1. just assign 1 here 
            while (columnsCount > 0)
            {
                columnsCount--;
                rangeColName = (char)('A' + columnsCount % 26) + rangeColName;
                columnsCount /= 26;
            }
    
            rangeInput = "A" + rowStartRange + ":" + rangeColName + "0";
    
    
    
            return rangeInput;
        }
    // Get Sheet Name assuming only one sheet for workbook and no hidden sheets
     public string GetSheetName(string filepath)
     {
     string sheetname = "";
     String connect = ExcelConn(filepath);
     OleDbConnection con = new OleDbConnection(connect);
     con.Open();
    
     DataTable tables = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
    
            foreach (DataRow row in tables.Rows)
            {
                sheetname = row[2].ToString();
                if (!sheetname.EndsWith("$"))
                    continue;
                
            }
    
      con.Close();
      return sheetname;
     }
     
    // Get number of columns in a given sheet
        public int GetNumberOfColumnsInSheet(string SheetName, string excelConnectionString)
        {
            int columnsCount = 0;
            
            //If a valid excel file
            if (!string.IsNullOrEmpty(excelConnectionString))
            {
                using (OleDbConnection conn = new OleDbConnection(excelConnectionString))
                {
                    conn.Open();
                    DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, null);
                    if (dt.Rows.Count > 0)
                    columnsCount = dt.AsEnumerable().Where(a => a["TABLE_NAME"].ToString() == SheetName).Count();
                    conn.Close();
                }
            }
            return columnsCount;
        }
    	
	
    // Get the first row count in sheet contains some keyword . This method call is optional if you always want A1. Here I need to check some keyword exist and from there only I have to start something like A4
     
    public int GetStartRowRange(string SheetName, string excelConnectionString)
     {
         int rowStartRange = 1;
    
         //If a valid excel file
         if (!string.IsNullOrEmpty(excelConnectionString))
         {
             using (OleDbConnection conn = new OleDbConnection(excelConnectionString))
             {
                 string colValue;
                 conn.Open();
                 string cmdstr = "select * from [" + SheetName + "]";
    
                 OleDbCommand com = new OleDbCommand(cmdstr, conn);
                 DataTable dt = new DataTable();
                 OleDbDataAdapter da = new OleDbDataAdapter(com);
                 da.Fill(dt);
    
                
    
                 // get first row data where it started
    
                 foreach (DataRow dataRow in dt.Rows)
                 {
    
                     colValue = dataRow[0].ToString();
    
                    
                     if ((colValue.Contains("Value1") || colValue.Contains("Value2") || colValue.Contains("Value3")) && (string.IsNullOrEmpty(dataRow[1].ToString()) == false))
                     {
                         rowStartRange = rowStartRange + 1;
                         break;
                     }
                     else
                     {
                         rowStartRange = rowStartRange + 1;
                     }
    
                 }
    
                 conn.Close();
    
    
             }
    
         }
         return rowStartRange;
     }
    // Connection to excel document
    public string ExcelConn(string FilePath)
    {
        string constr = "";
        string extension = Path.GetExtension(FilePath);
    
        //Checking for the extentions, if XLS connect using Jet OleDB
        if (extension.Equals(".xls", StringComparison.CurrentCultureIgnoreCase))
        {
            constr = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; Data Source={0};Extended Properties=\"Excel 12.0;IMEX=1;HDR=YES\"", FilePath);
        }
        //Use ACE OleDb if xlsx extention
        else if (extension.Equals(".xlsx", StringComparison.CurrentCultureIgnoreCase))
        {
            constr = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 8.0;IMEX=1;HDR=YES\"", FilePath);
        }
    
    
        return constr;
    
    } // end of ExcelConn method
