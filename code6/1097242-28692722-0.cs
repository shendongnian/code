       for (var i = 0; i < dtdata.Rows.Count; i++)
            {
                if (dtdata.Rows[i]["typeName"].ToString() == "Annual Leave")
                {
                    ws.Cells[i + 2, 5].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    ws.Cells[i + 2, 5].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightYellow);
                }
                else if (dtdata.Rows[i]["typeName"].ToString() == "Available")
                {
                    ws.Cells[i + 2, 5].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    ws.Cells[i + 2, 5].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGreen);
                }
                else
                {
                    ws.Cells[i + 2, 5].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    ws.Cells[i + 2, 5].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.White);
                }
            }
