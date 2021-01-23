    var names = new[]
    {
        "Brady, Tom",
        "Manning, Peyton",
        "Peterson, Adrian",
        "Lewis, Ray",
        "Reed, Ed",
        "Polamalu, Troy",
        "Johnson, Andre",
        "Revis, Darrelle",
        "Brees, Drew",
        "Peppers, Julius"
    };
    // Write names to a file
    using (var excelPackage = new ExcelPackage(new FileInfo(@"d:\tmp\TextToColumns.xlsx")))
    {
        var worksheet = excelPackage.Workbook.Worksheets.Add("TextToColumns");
        for (int i = 1; i < names.Length; i++)
        {
            worksheet.Cells[String.Format("A{0}", i)].Value = names[i - 1];
        }
        excelPackage.Save();
    }
    // Split names
    using (var excelPackage = new ExcelPackage(new FileInfo(@"d:\tmp\TextToColumns.xlsx")))
    {
        var worksheet = excelPackage.Workbook.Worksheets.First();
        foreach (var cell in worksheet.Cells)
        {
            var splittedValues = ((String)cell.Value).Split(',');
            // Write last name to the first column
            cell.Value = splittedValues[0];
            // Write first name to the next one column
            worksheet.Cells[cell.Start.Row, cell.Start.Column + 1].Value = splittedValues[1].TrimStart();
        }
        excelPackage.Save();
    }
