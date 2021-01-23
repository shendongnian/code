    class Retriever
    {
        public List<SheetName> GetSheetNames(OleDbConnection conn)
        {
            List<SheetName> sheetNames = new List<SheetName>();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            DataTable excelSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            foreach (DataRow row in excelSchema.Rows)
            {
                if (!row["TABLE_NAME"].ToString().Contains("FilterDatabase"))
                {
                   sheetNames.Add(new SheetName() { sheetName = row["TABLE_NAME"].ToString(), sheetType = row["TABLE_TYPE"].ToString(), sheetCatalog = row["TABLE_CATALOG"].ToString(), sheetSchema = row["TABLE_SCHEMA"].ToString() });
                }
            }
            conn.Close();
            return sheetNames;
         }
    } 
    
    class SheetName
    {
         public string sheetName { get; set; }
         public string sheetType { get; set; }
         public string sheetCatalog { get; set; }
         public string sheetSchema { get; set; }
    }
