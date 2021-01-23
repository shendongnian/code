    protected void btnUpload_Click(object sender, EventArgs e)
            {
                if (fileUpload.HasFile)
                {
                    string path = string.Concat(Server.MapPath("~/File/" + fileUpload.FileName));
                    fileUpload.SaveAs(path);
    
                    Microsoft.Office.Interop.Excel.Application appExcel;
                    Microsoft.Office.Interop.Excel.Workbook workbook;
                    Microsoft.Office.Interop.Excel.Range range;
                    Microsoft.Office.Interop.Excel._Worksheet worksheet;
    
                    appExcel = new Microsoft.Office.Interop.Excel.Application();
                    workbook = appExcel.Workbooks.Open(path, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                    worksheet = (Microsoft.Office.Interop.Excel._Worksheet)workbook.Sheets[1];
                    range = worksheet.UsedRange;
    
                    int rowCount = range.Rows.Count;
                    int colCount = range.Columns.Count;
    
                    System.Data.DataTable dt = new System.Data.DataTable();
                    dt.Columns.Add("npm");
                    dt.Columns.Add("prodi");
                    dt.Columns.Add("grade");
    
                    for (int Rnum = 3; Rnum <= rowCount; Rnum++)
                    {
                        DataRow dr = dt.NewRow();
                        //Reading Each Column value From sheet to datatable Colunms                  
                        for (int Cnum = 1; Cnum <= colCount; Cnum++)
                        {
                            dr[Cnum - 1] = (range.Cells[Rnum, Cnum]).Value2.ToString();
                        }
                        dt.Rows.Add(dr); // adding Row into DataTable
                        dt.AcceptChanges();
                    }
    
                    workbook.Close(true);
                    appExcel.Quit();
    
                    try
                    {
                        string connSql = @"Data Source=.; Database=dbkuring; User Id=sa; Password=pohodeui;";
    
                        SqlBulkCopy bulkcopy = new SqlBulkCopy(connSql);
    
                        SqlBulkCopyColumnMapping mapNPM = new SqlBulkCopyColumnMapping("npm", "npm");
                        bulkcopy.ColumnMappings.Add(mapNPM);
                        SqlBulkCopyColumnMapping mapProdi = new SqlBulkCopyColumnMapping("prodi", "prodi");
                        bulkcopy.ColumnMappings.Add(mapProdi);
                        SqlBulkCopyColumnMapping mapGrade = new SqlBulkCopyColumnMapping("grade", "grade");
                        bulkcopy.ColumnMappings.Add(mapGrade);
    
                        bulkcopy.DestinationTableName = "testUpload";
                        bulkcopy.WriteToServer(dt);
    
                        msg.Text = "success";
                    }
                    catch (Exception ex)
                    {
                        msg.Text = ex.Message.ToString();
                    }
    
                    
                }
            }
