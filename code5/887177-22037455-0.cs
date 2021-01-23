    System.Data.DataTable table1 = new System.Data.DataTable();
                OleDbConnection dbConnection1 =
                        new OleDbConnection
                          (@"Provider=Microsoft.Jet.OLEDB.4.0;"
                           + @"Data Source=YourFileName.xls;"
                           + @"Extended Properties=Excel 8.0;HDR=Yes;");
                dbConnection1.Open();
                try
                {
                    OleDbDataAdapter dbAdapter1 =
                        new OleDbDataAdapter
                            ("SELECT * FROM [Sheet1$]", dbConnection1);
                    dbAdapter1.Fill(table1);
                }
                finally
                {
                    dbConnection1.Close();
                }
