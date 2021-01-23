    ExcelPackage package = new ExcelPackage();
    package.Workbook.Properties.Comments = "Demo Excel Generation";
    package.Workbook.Worksheets.Add("DemoSheet");
    ExcelWorksheet sheet = package.Workbook.Worksheets["DemoSheet"];
    bool altColour = false;
    for (int i = 1; i < 10; i++)
    {
        for (int j = 1; j < 10; j++)
        {
            sheet.Cells[i, j].Value = string.Format("{0} - {1}", i, j);
            sheet.Row(j).Style.Fill.PatternType = ExcelFillStyle.Solid;
            sheet.Row(j).Style.Fill.BackgroundColor.SetColor(altColour ? Color.Gold : Color.Goldenrod);
            altColour = !altColour;
        }
        sheet.Column(i).AutoFit(5f); // Set minimum width to 5 points
    }
    package.File = new System.IO.FileInfo(@"C:\test.xlsx");
    package.Save();
