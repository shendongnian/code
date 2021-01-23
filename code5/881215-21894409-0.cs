        var package = new ExcelPackage();
        using (var stream = File.OpenRead(tmpExcel))
        {
            package.Load(stream);
        }
        var worksheet = package.Workbook.Worksheets["Common-Lookup"];
        // Access Named Ranges from the ExcelWorkbook instead of ExcelWorksheet
        //using (ExcelNamedRange namedRange = worksheet.Names["LupVerticalSettings"])
        // use package.Workbook.Names instead of worksheet.Names
        using (ExcelNamedRange namedRange = package.Workbook.Names["LupVerticalSettings"])
        {
            for (var row = namedRange.Start.Row; row <= namedRange.End.Row; row++)
            {
                for (var col = namedRange.Start.Column; col <= namedRange.End.Column; col++)
                {
                    _.Nv(worksheet.Cells[row, col].Address, worksheet.Cells[row, col].Text);
                    //worksheet.Cells[rowIndex, columnIndex].Value = "no more hair pulling";
                }
            }
        }
