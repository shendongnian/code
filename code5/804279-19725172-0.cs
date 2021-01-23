    var model = new PlotModel("IntervalBarSeries") { LegendPlacement =  LegendPlacement.Outside };
    var temp_serie = new IntervalBarSeries 
	{ 
		Title = "IntervalBarSeries 1", 
		FillColor = OxyColors.Black
	};
    var categoryAxis = new CategoryAxis
	{
		Position = AxisPosition.Left,
		IsZoomEnabled = false,	// No zoom on this axis
		IsPanEnabled = false,   // Right mouse move won't affect this axis
		MajorGridlineStyle = LineStyle.Solid
		,StartPosition = 1, EndPosition = 0 // This will reverse the order
					
	};
    var valueAxis = new LinearAxis(AxisPosition.Top)
	{
		MinimumPadding = 0.1, MaximumPadding = 0.1, 
		IsZoomEnabled = true, 
		MajorGridlineStyle = LineStyle.Solid,
		MajorStep = 3600,
		AbsoluteMinimum = 0
	};
	
    for (int i = 10; i > 2; i--)
    {
	temp_serie.Items.Add(new IntervalBarItem { 
		Start = rand.Next(3600, 7200), 
		End = rand.Next(30000, 80000) 
	});
	
	categoryAxis.Labels.Add("Activity "+i);
    }
    model.Series.Add(temp_serie);	
    model.Axes.Add(categoryAxis);
    model.Axes.Add(valueAxis);
    MyPlotModel = model;
