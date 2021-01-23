    public class ExcelExportHelper
    	{
    		public static string ExcelContentType { get { return "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"; } }
    
    		public static DataTable ToDataTable<T>(List<T> data)
            {
                PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
                DataTable table = new DataTable();
    
                for (int i = 0; i < props.Count; i++)
                {
                    PropertyDescriptor prop = props[i];
                    //table.Columns.Add(prop.Name, prop.PropertyType);
    				table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType); // to avoid nullable types
                }
    
                object[] values = new object[props.Count];
                foreach (T item in data)
                {
                    for (int i = 0; i < values.Length; i++)
                    {
                        values[i] = props[i].GetValue(item);
                    }
    
                    table.Rows.Add(values);
                }
                return table;
            }
    
    		public static byte[] ExportExcel(DataTable dt, string Heading = "", params string[] IgnoredColumns)
            {
    			byte[] result = null;
    			using (ExcelPackage pck = new ExcelPackage())
                {
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Exported Data");
    				int StartFromRow = String.IsNullOrEmpty(Heading) ? 1: 3;
    
    				// add the content into the Excel file
    				ws.Cells["A" + StartFromRow].LoadFromDataTable(dt, true);
    				
    				// autofit width of cells with small content
                    int colindex = 1;
                    foreach (DataColumn col in dt.Columns)
                    {
                        ExcelRange columnCells = ws.Cells[ws.Dimension.Start.Row, colindex, ws.Dimension.End.Row, colindex];
                        int maxLength = columnCells.Max(cell => cell.Value.ToString().Count());
                        if (maxLength < 150)
                            ws.Column(colindex).AutoFit();
    
                        colindex++;
                    }
    
    				// format header - bold, yellow on black
    				using (ExcelRange r = ws.Cells[StartFromRow, 1, StartFromRow, dt.Columns.Count])
                    { 
                        r.Style.Font.Color.SetColor(System.Drawing.Color.Yellow);
                        r.Style.Font.Bold = true;
                        r.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        r.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Black);
                    }
    
    				// format cells - add borders
    				using (ExcelRange r = ws.Cells[StartFromRow + 1, 1, StartFromRow + dt.Rows.Count, dt.Columns.Count])
    				{
    					r.Style.Border.Top.Style = ExcelBorderStyle.Thin;
    					r.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
    					r.Style.Border.Left.Style = ExcelBorderStyle.Thin;
    					r.Style.Border.Right.Style = ExcelBorderStyle.Thin;
    
    					r.Style.Border.Top.Color.SetColor(System.Drawing.Color.Black);
    					r.Style.Border.Bottom.Color.SetColor(System.Drawing.Color.Black);
    					r.Style.Border.Left.Color.SetColor(System.Drawing.Color.Black);
    					r.Style.Border.Right.Color.SetColor(System.Drawing.Color.Black);
    				}
    
    				// removed ignored columns
    				for (int i = dt.Columns.Count - 1; i >= 0; i--)
    				{
    					if (IgnoredColumns.Contains(dt.Columns[i].ColumnName))
    					{
    						ws.DeleteColumn(i + 1);
    					}
    				}
    
    				// add header and an additional column (left) and row (top)
    				if (!String.IsNullOrEmpty(Heading))
    				{
    					ws.Cells["A1"].Value = Heading;
    					ws.Cells["A1"].Style.Font.Size = 20;
    
    					ws.InsertColumn(1, 1);
    					ws.InsertRow(1, 1);
    					ws.Column(1).Width = 5;
    				}
    
    				result = pck.GetAsByteArray();
                }
    
    			return result;
            }
    
            public static byte[] ExportExcel<T>(List<T> data, string Heading = "", params string[] IgnoredColumns)
            {
                return ExportExcel(ToDataTable<T>(data), Heading, IgnoredColumns);
            }
    	}
