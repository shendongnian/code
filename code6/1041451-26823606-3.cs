        static void XLSFileStreamReader(string filePath)
        {
            FileStream stream = new FileStream(filePath, FileMode.Open);
               
            // Reading from a binary Excel file ('97-2003 format; *.xls)
            IExcelDataReader excelReader2003 = ExcelReaderFactory.CreateBinaryReader(stream);
            
            // DataSet - The result of each spreadsheet will be created in the result.Tables
            DataSet result = excelReader2003.AsDataSet();
 
            // Data Reader methods
            foreach (DataTable table in result.Tables)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    for (int j = 0; j < table.Columns.Count; j++)
                        Console.Write("\"" + table.Rows[i].ItemArray[j] + "\";");
                    Console.WriteLine();
                }
            }
 
            // Free resources (IExcelDataReader is IDisposable)
            excelReader2003.Close();
        }
