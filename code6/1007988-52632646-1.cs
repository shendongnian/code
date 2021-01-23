    public static void ExportToExcel(HttpContext ctx, DataTable tbl, string fileName)
            {
                try
                {
                    using (ExcelPackage pck = new ExcelPackage())
                    {
                        //Create the worksheet
                        ExcelWorksheet ws = pck.Workbook.Worksheets.Add(fileName);
    
                        //Load the datatable into the sheet, starting from cell A1. Print the column names on row 1
                        ws.Cells["A1"].LoadFromDataTable(tbl, true);
    
                        int rowCount = tbl.Rows.Count;
                        List<int> dateColumns = new List<int>();
                        foreach (DataColumn d in tbl.Columns)
                        {
                            if (d.DataType == typeof(DateTime))
                                dateColumns.Add(d.Ordinal + 1);
                        }
    
                        CultureInfo info = new CultureInfo(ctx.Session["Language"].ToString());
    
                        foreach (int dc in dateColumns)
                            ws.Cells[2, dc, rowCount + 1, dc].Style.Numberformat.Format = info.DateTimeFormat.ShortDatePattern;
    
                        //Write it back to the client
                        ctx.Response.Clear();
                        ctx.Response.AddHeader("content-disposition", "attachment;  filename=" + fileName + ".xlsx");
                        ctx.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        ctx.Response.Buffer = false;
                        ctx.Response.BufferOutput = false;
                        ctx.Response.BinaryWrite(pck.GetAsByteArray());
                        ctx.Response.End();
                    }
                }
                catch (Exception EX)
                {
                    ctx.Response.Write(EX.ToString());
                }
            }
