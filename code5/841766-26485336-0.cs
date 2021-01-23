        var reportFilterNames = new List<string>(); //TODO: Fill with column names from DataTable
        var valueNames = new List<string>(); //TODO: Fill with column names from DataTable
        ExcelWorksheet dataWorksheet = package.Workbook.Worksheets[report.ReportType];
        ExcelRange dataRange = dataWorksheet.Cells["A1:" + dataWorksheet.Dimension.End.Address];
        ExcelWorksheet pivotWorksheet = package.Workbook.Worksheets.Add(dt.TableName);
        ExcelRange pivotDataRange = pivotWorksheet.Cells["A" + (2 + reportFilterNames.Count)];
        ExcelPivotTable pivotTable = pivotWorksheet.PivotTables.Add(pivotDataRange, dataRange, "Stats");
        pivotTable.DataOnRows = false;
        pivotTable.RowFields.Add(pivotTable.Fields["DATE"]);
        foreach (string reportFilterName in reportFilterNames)
            pivotTable.PageFields.Add(pivotTable.Fields[reportFilterName]);
        foreach (string valueName in valueNames)
            pivotTable.DataFields.Add(pivotTable.Fields[valueName]);
        var chart = pivotWorksheet.Drawings.AddChart("PivotChart", eChartType.Line, pivotTable);
        chart.SetPosition(1, 0, 4, 0);
        chart.SetSize(1200, 800);
