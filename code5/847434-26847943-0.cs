    PlotView resultsChart = FindViewById<PlotView>(Resource.Id.resultsChart);
    PlotModel plotModel = new PlotModel
    {
        // set here main properties such as the legend, the title, etc. example :
        Title = "My Awesome Real-Time Updated Chart",
        TitleHorizontalAlignment = TitleHorizontalAlignment.CenteredWithinPlotArea,
        LegendTitle = "I am a Legend",
        LegendOrientation = LegendOrientation.Horizontal,
        LegendPlacement = LegendPlacement.Inside,
        LegendPosition = LegendPosition.TopRight
        // there are many other properties you can set here
    }
    // now let's define X and Y axis for the plot model
    LinearAxis xAxis = new LinearAxis();
    xAxis.Position = AxisPosition.Bottom;
    xAxis.Title = "Time (hours)";
    LinearAxis yAxis = new LinearAxis();
    yAxis.Position = AxisPosition.Left;
    yAxis.Title = "Values";
    plotModel.Axes.Add(xAxis);
    plotModel.Axes.Add(yAxis);
    // Finally let's define a LineSerie
    LineSeries lineSerie = new LineSeries
     {
        StrokeThickness = 2,
        CanTrackerInterpolatePoints = false,
        Title =  "Value",
        Smooth = false
      };
    plotModel.Series.Add(lineSerie);
    resultsChart.Model = plotModel;
