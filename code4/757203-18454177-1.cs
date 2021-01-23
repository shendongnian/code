    double left = windowInfo.ColumnToPoints(2.0);
    double top = windowInfo.RowToPoints(1.0);
    double right = windowInfo.ColumnToPoints(9.0);
    double bottom = windowInfo.RowToPoints(16.0);
    SpreadsheetGear.Charts.IChart chart =
        worksheet.Shapes.AddChart(left, top, right - left, bottom - top).Chart;
    
    // Set the chart's source data range, plotting series in columns.
    chart.SetSourceData(dataRange, SpreadsheetGear.Charts.RowCol.Columns);
    
    // Set the chart type.
    chart.ChartType = SpreadsheetGear.Charts.ChartType.Area;
    
    // Set the axis label format to the data range
    chart.Axes[AxisType.Value].TickLabels.NumberFormatLinked = true;
