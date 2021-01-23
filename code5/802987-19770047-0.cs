    private void SetPlot()
    {
        var model = new PlotModel("Metas")
        {
            LegendPlacement = LegendPlacement.Outside,
            LegendPosition = LegendPosition.BottomCenter,
            LegendOrientation = LegendOrientation.Horizontal,
            LegendBorderThickness = 0
        };
        var goals = new ColumnSeries {
            Title = "Goals",
            FillColor = OxyColors.Orange,
            IsStacked = true,
            StrokeColor = OxyColors.Black,
            StrokeThickness = 1
        };
        var sales = new ColumnSeries {
            Title = "Sales",
            FillColor = OxyColors.LightGreen,
            IsStacked = true,
            StrokeColor = OxyColors.White,
            StrokeThickness = 1
        };
        var surplus = new ColumnSeries {
            Title = "Surplus",
            FillColor = OxyColors.Cyan,
            IsStacked = true,
            StrokeColor = OxyColors.Black,
            StrokeThickness = 1
        };
        var categoryAxisForMonths = new CategoryAxis { 
            Position = AxisPosition.Bottom 
        };
        var valueAxis = new LinearAxis (AxisPosition.Left) { 
            MinimumPadding = 0, 
            MaximumPadding = 0.06, 
            AbsoluteMinimum = 0 
        };
        // Creating random data for 12 months
        for (int i = 0; i < 12; i++)
        {
            //var goal = 10;   // if you want a set goal, use this
            var goal = RandomHelper.RandomInt(8, 11); // otherwise use this
            var actualsales = RandomHelper.RandomInt(5, 15);
            if (actualsales > goal)
            {
                sales.Items.Add  (new ColumnItem( goal               ));
                surplus.Items.Add(new ColumnItem( actualsales-goal   ));
                goals.Items.Add  (new ColumnItem( 0                  ));
            }
            else
            {
                sales.Items.Add  (new ColumnItem( actualsales        ));
                goals.Items.Add  (new ColumnItem( goal - actualsales ));
                surplus.Items.Add(new ColumnItem( 0                  ));
            }
            // Next will create jan - dec in the labels
            categoryAxisForMonths.Labels.Add(CultureInfo.CurrentUICulture.DateTimeFormat.MonthNames[i]);
        }
        model.Series.Add (sales);
        model.Series.Add (goals);
        model.Series.Add (surplus);
        model.Axes.Add (categoryAxisForMonths);
        model.Axes.Add (valueAxis);
        MyPlotModel = model;
    }
    public PlotModel MyPlotModel { get; set; }
