         DataTable dt= dtData;
       using (XLWorkbook wb = new XLWorkbook())
       {       
   
                     //Range(int firstCellRow,int firstCellColumn,int lastCellRow,int lastCellColumn)
                    int CCount = dt.Columns.Count;
                    int RCount = dt.Rows.Count;
                    var ws = wb.Worksheets.Add("Report"); //add worksheet to workbook
                    ws.Row(1).Cell(1).RichText.AddText(ReportName);
                    ws.Range(1, 1, 1, CCount).Merge();
                    ws.Range(1, 1, 1, CCount).Style.Font.Bold = true;//Range(int firstCellRow,int firstCellColumn,int lastCellRow,int lastCellColumn)
                    ws.Range(1, 1, 1, CCount).Style.Font.FontSize = 16;
                    ws.Range(1, 1, 1, CCount).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    ws.Range(1, 1, 1, CCount).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    //ws.Range("A1:Z1").Style.Font.Bold = true;
                    ws.Row(2).Cell(1).InsertTable(dt);
                    ws.Range("A2:Z2").Style.Font.Bold = true;
                    ws.Range(2, 1, RCount + 2, CCount).Style.Border.OutsideBorder = XLBorderStyleValues.Medium;
                    wb.SaveAs(FolderPath + filename + ".xlsx");
                    ws.Dispose();
                
            }
