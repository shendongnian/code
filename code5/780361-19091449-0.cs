        private void insert_Click(object sender, EventArgs e)
        {
            UInt64 ID = 0;
            String Name = String.Empty;
            String Designation = String.Empty;
            String ProfilePicture = String.Empty;
            String filePath = filePathText.Text;
            Excel.Application xlApp = null;
            Excel.Workbook xlWorkbook = null;
            Excel._Worksheet xlWorksheet = null;
            Excel.Range xlRange = null;
            String sqlConnectionString = "Your Connection String goes here";
            String insertRecord = "INSERT_USER_RECORDS";
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionString);
            SqlCommand sqlCommand = new SqlCommand(insertRecord, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlConnection.Open();
            if (filePath != null)
            {
                try
                {
                    xlApp = new Excel.Application();
                    xlWorkbook = xlApp.Workbooks.Open(filePath);
                    xlWorksheet = (Excel._Worksheet)xlWorkbook.Sheets[1];
                    xlRange = xlWorksheet.UsedRange;
                    int rowCount = xlRange.Rows.Count;
                    int colCount = xlRange.Columns.Count;
                    for (int i = 1; i <= rowCount; i++)
                    {
                        for (int j = 1; j <= colCount; j++)
                        {
                            MessageBox.Show((xlRange.Cells[i, j] as Microsoft.Office.Interop.Excel.Range).Value2.ToString());
							
							// Check xlRange for Every run. And assign values to local variables. Here I just show the values using MsgBox
							
							// If you get the Path of Image then call the function to Convert Image into byte
							
							// Convert Image to Byte Function definition.
							
							/* System.IO.FileStream fs = new System.IO.FileStream(ProfilePicture, System.IO.FileMode.Open);
							   Byte[] imageAsBytes = new Byte[fs.Length];
							   fs.Read(imageAsBytes, 0, imageAsBytes.Length);
							   fs.Close();
							   return imageAsBytes; */
							
                        }
                        sqlCommand.Parameters.Clear();
                        sqlCommand.Parameters.Add("@Name", SqlDbType.NVarChar).Value = FirstName;
                        sqlCommand.Parameters.Add("@Designation", SqlDbType.NVarChar).Value = LastName;
                        sqlCommand.Parameters.Add("@ProfilePicture", SqlDbType.VarBinary).Value = imageAsBytes;
                        sqlCommand.Parameters.Add("@ID", SqlDbType.BigInt).Value = ID;
                        sqlCommand.ExecuteNonQuery();
                    }
                    MessageBox.Show(Path.GetFileName(filePath) + "is Successfully imported to SQL Server", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    //Release All objects and close the Connection to prevent the Excel file from lock.
					
					sqlConnection.Close();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                   
                    Marshal.FinalReleaseComObject(xlRange);
                    Marshal.FinalReleaseComObject(xlWorksheet);
                    
                    xlWorkbook.Close(Type.Missing, Type.Missing, Type.Missing);
                    Marshal.FinalReleaseComObject(xlWorkbook);
                    
                    xlApp.Quit();
                    Marshal.FinalReleaseComObject(xlApp);
                    
                }
            }
            else
            {
                MessageBox.Show("Please Select the Valid file to import");
            }
        }
