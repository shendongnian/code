    LegendItem newItem = new LegendItem();
    newItem.ImageStyle = LegendImageStyle.Line;
    newItem.Color = lineColor;
    newItem.BorderWidth = 2;
    newItem.Cells.Add(LegendCellType.SeriesSymbol, "", ContentAlignment.MiddleLeft); // Symbol
    newItem.Cells.Add(LegendCellType.Text, seriesName, ContentAlignment.MiddleLeft); // Series Name
    newItem.Cells.Add(LegendCellType.Text, "", ContentAlignment.MiddleLeft); // Value
    ...
    ...
    series.IsVisibleInLegend = false;
    _chart.Series.Add(series);
