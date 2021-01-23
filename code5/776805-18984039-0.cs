        public void ExportExcelFile(System.Data.DataTable excelData, string excelSheetName)
        {
            using (var package = new ExcelPackage())
            {
                ExcelWorksheet ws = package.Workbook.Worksheets.Add(excelSheetName);
                HtmlAnchor lnkOpen = new HtmlAnchor();
                int rowCount = 1;
                foreach (DataRow rw in excelData.Rows)
                {
                    
                    rowCount += 1;
                    for (int i = 1; i < excelData.Columns.Count + 1; i++)
                    {
                        // Add the header the first time through 
                        if (rowCount == 2)
                        {
                            ws.Row(1).Style.Font.Bold = true;
                            ws.Cells[1, i].Value = excelData.Columns[i - 1].ColumnName;
                        }
                        ws.Column(i).AutoFit();
                        
                        if (excelData.Columns[i - 1].ColumnName.ToString() == "Drawing Id" )
                        {
                         //var hyperlink = String.Format("Http://" + Page.Request.Url.Host + "/Documents/DownloadFile.aspx?id={0}", rw["DocPk"].ToString());
                         var hyperlink = String.Format(ConfigurationManager.AppSettings["DocumentManagerURL"] + "Documents/DownloadFile.aspx?id={0}", rw["DocPk"].ToString());
                          ws.Cells[rowCount, i].Hyperlink = new Uri(hyperlink, UriKind.Absolute);
                          ws.Cells[rowCount, i].Style.Font.UnderLine = true;
                          ws.Cells[rowCount, i].Style.Font.Color.SetColor(System.Drawing.Color.Blue);
                          ws.Cells[rowCount, i].Value = rw["Drawing Id"]; 
                        }
                        else{
                          ws.Cells[rowCount, i].Value = rw[i - 1].ToString();  
                        }
                        
                    }
                    //excelData.Columns.RemoveAt(7);
                }
                MemoryStream Result = new MemoryStream();
                package.SaveAs(Result);
                Response.ClearContent();
                Response.OutputStream.Write(Result.GetBuffer(), 0, Result.GetBuffer().Length);
                Response.OutputStream.Flush();
                Response.OutputStream.Close();
                byte[] byteArray = Result.ToArray();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + excelSheetName + ".xlsx");
                Response.AddHeader("Content-Length", byteArray.Length.ToString());
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.BinaryWrite(byteArray);
                Response.End();
            }
        }
