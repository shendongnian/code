    // Setup a new Excel package (workbook).
    using (var package = new ExcelPackage(newFile))
    {
        // Create a a new worksheet in the workbook.
        var worksheet = package.Workbook.Worksheets.Add("Files");
        // Set the titles for the columns.
        worksheet.Cells[1, 1].Value = "Date";
        worksheet.Cells[1, 2].Value = "Time";
        worksheet.Cells[1, 3].Value = "File Name";
        worksheet.Cells[1, 4].Value = "Location";
        worksheet.Cells[1, 5].Value = "Size";
        worksheet.Cells[1, 6].Value = "Comments";
        // Set formatting for the titles.
        using (var range = worksheet.Cells[1, 1, 1, 6])
        {
            range.Style.Font.Bold = true;
            range.Style.Fill.PatternType = ExcelFillStyle.Solid;
            range.Style.Fill.BackgroundColor.SetColor(Color.RoyalBlue);
            range.Style.Font.Color.SetColor(Color.White);
            range.Style.WrapText = true;
        }
        // Set the titles to repeat.
        worksheet.PrinterSettings.RepeatRows = new ExcelAddress("1:1");
        // Set worksheet to print in landscape.
        worksheet.PrinterSettings.Orientation = eOrientation.Landscape;
        // Set the worksheet to fit all columns.
        worksheet.PrinterSettings.FitToPage = true;
        worksheet.PrinterSettings.FitToWidth = 1;
        worksheet.PrinterSettings.FitToHeight = 0;
        // Set the border to separate data.
        worksheet.Cells.Style.Border.Left.Style = ExcelBorderStyle.Thin;
        worksheet.Cells.Style.Border.Top.Style = ExcelBorderStyle.Thin;
        worksheet.Cells.Style.Border.Right.Style = ExcelBorderStyle.Thin;
        worksheet.Cells.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
        for (int i = 0, row = 2; i < files.Count; i++, row++)
        {
                worksheet.Cells[String.Format("A{0}", row)].Value = files[i].Date;
                worksheet.Cells[String.Format("B{0}", row)].Value = files[i].Time;
                worksheet.Cells[String.Format("C{0}", row)].Value = files[i].FileName;
                worksheet.Cells[String.Format("D{0}", row)].Value = files[i].Location;
                worksheet.Cells[String.Format("E{0}", row)].Value = files[i].Size;
                worksheet.Cells[String.Format("E{0}", row)].Style.Numberformat.Format = "0";
                worksheet.Cells[String.Format("F{0}", row)].Value = files[i].Comments;
        }
        // Auto fit all columns.
        worksheet.Cells.AutoFitColumns();
        package.Save();
    }
