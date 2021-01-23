            var newDataFormat = workbook.CreateDataFormat();
            var style = workbook.CreateCellStyle();
            style.BorderBottom = BorderStyle.Thin;
            style.BorderLeft = BorderStyle.Thin;
            style.BorderTop = BorderStyle.Thin;
            style.BorderRight = BorderStyle.Thin;
            style.DataFormat = newDataFormat.GetFormat("MM/dd/yyyy HH:mm:ss");
            foreach (var objArticles in tempArticles)
            {
                //Create a new Row
                var row = sheet.CreateRow(rowNumber++);
                //Set the Values for Cells
                row.CreateCell(0).SetCellValue(objArticles.ProjectId);
                row.CreateCell(1).SetCellValue(objArticles.ProjectName);
                row.CreateCell(2).SetCellValue(objArticles.MetricDescription);
                row.CreateCell(3).SetCellValue(objArticles.MetricValue);             
                var cell = row.CreateCell(4);
                cell.SetCellValue(objArticles.BuildDate);
                cell.CellStyle = style; 
                var cell5 = row.CreateCell(5);
                cell5.SetCellValue(objArticles.CreateDate);
                cell5.CellStyle = style;
            }
