    var chart = new SerialChart
    {
        CategoryValueMemberPath = "month",
        AxisForeground = new SolidColorBrush(Colors.White),
        PlotAreaBackground = new SolidColorBrush(Colors.Black),
        GridStroke = new SolidColorBrush(Colors.DarkGray)
    };
    chart.SetBinding(SerialChart.DataSourceProperty, new Binding("results"));
    var lineGraph = new LineGraph
    {
        Title = "Sales",
        ValueMemberPath = "actual",
        Brush = new SolidColorBrush(Colors.Red),
        StrokeThickness = "5"
    };
    chart.Graphs.Add(lineGraph);
   
