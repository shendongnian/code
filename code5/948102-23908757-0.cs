    [SqlProcedure()]
        public static void GetMyTestData(
            SqlString sqlQuery, SqlString fileName)
        {
            using (SqlConnection conn = new SqlConnection("context connection=true"))
            {
                SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                
                //Fill a C# dataset with query results
                DataTable t1 = new DataTable();
                using (SqlDataAdapter a = new SqlDataAdapter(cmd))
                {
                    a.Fill(t1);
                }
    
                //Assign filename to a variable
                
                var file = new FileInfo(fileName);
    
                //Load the data table into the excel file and save
                using (ExcelPackage pck = new ExcelPackage(file))
                {
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Data");
                    ws.Cells["A1"].LoadFromDataTable(t1, true);
                    pck.Save();
                }
    
                conn.Close();
            }
        }
