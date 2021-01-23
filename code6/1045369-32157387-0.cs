    // Create a plot model
    PlotModel = new PlotModel { Title = "Updating by task running on the UI thread" };
    // Add the axes, note that MinimumPadding and AbsoluteMinimum should be set on the value axis.
    PlotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, TextColor = OxyColors.Transparent});
  
