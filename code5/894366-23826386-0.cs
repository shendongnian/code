    // Create your Data Series
    var xyDataSeries = new XyDataSeries<TimeSpan, double>();
    // Append some values
    xyDataSeries.Append(TimeSpan.FromSeconds(0), 0);
    xyDataSeries.Append(TimeSpan.FromSeconds(1), 1);
    xyDataSeries.Append(TimeSpan.FromSeconds(2), 2);
    // ... 
    xyDataSeries.Append(TimeSpan.FromSeconds(11), 11); 
 
    // Set the XyDataSeries on the RenderableSeries
    // Assumes chart is created as per your XAML above
    sciChart.RenderableSeries[0].DataSeries = xyDataSeries;   
    // Zoom XAxis to fit first three points
    var xRange = new TimeSpanRange(xyDataSeries.XValues[0], xyDataSeries.XValues[2]);
    sciChart.XAxis.VisibleRange = xRange;
    // Zoom to fit in Y direction
    sciChart.ZoomExtentsY(); 
    
