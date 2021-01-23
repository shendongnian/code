    public static void DumpExcel(DataTable dataTable)
        {
            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("DataTable");
        
                worksheet.Cells["A1"].LoadFromDataTable(dataTable, true);
        
                for (int i = 1; i <= dataTable.Columns.Count; i++)
                {
                    worksheet.Column(i).AutoFit();
        
                    if (dataTable.Columns[i - 1].DataType == System.Type.GetType("System.DateTime"))
                    {
                        worksheet.Column(i).Style.Numberformat.Format = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                    }
                }
        
                HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                HttpContext.Current.Response.AddHeader("content-disposition", "attachment;  filename=table.xlsx");
                HttpContext.Current.Response.BinaryWrite(package.GetAsByteArray());
                HttpContext.Current.Response.End();
            }
        }
