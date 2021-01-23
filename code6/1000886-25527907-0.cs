    public Form1()
    {
        InitializeComponent();
        LineSeries series1 = new LineSeries();
        series1.Spline = true;
        series1.PointSize = new SizeF(15, 15);
        series1.DataPoints.Add(new CategoricalDataPoint() { Label = "val1", Value = 5 });
        series1.DataPoints.Add(new CategoricalDataPoint() { Label = "val2", Value = 1 });
        series1.DataPoints.Add(new CategoricalDataPoint() { Label = "val3", Value = 5 });
        series1.DataPoints.Add(new CategoricalDataPoint() { Label = "val4", Value = 2 });
        series1.DataPoints.Add(new CategoricalDataPoint() { Label = "val5", Value = 8 });
        radChartView1.Series.Add(series1);
        ChartSelectionController controller = new ChartSelectionController();
        controller.AllowSelect = true;
        controller.SelectionMode = ChartSelectionMode.SingleDataPoint;
        radChartView1.Controllers.Add(controller);
        radChartView1.SelectedPointChanged += radChartView1_SelectedPointChanged;
    }
    void radChartView1_SelectedPointChanged(object sender, Telerik.WinControls.UI.ChartViewSelectedPointChangedEventArgs e)
    {
        MessageBox.Show("WORKS!");
    }
    private void Form1_Load(object sender, EventArgs e)
    {
      
    }
