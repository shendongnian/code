                OleDbConnection conn = new OleDbConnection(strConn);
                conn.Open();
                DataTable schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });////gets the table from the tempFile
    
                List<DataTable> listInnerTable = new List<DataTable>();
    
                foreach (DataRow dr in schemaTable.Rows)
                {
                    DataTable innerTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new object[] { null, null, dr.ItemArray[2], null });
                    listInnerTable.Add(innerTable);
                }
