    public graph()
        {
            InitializeComponent();
            this.DataContext = this;
            _voltagePointCollection = new VoltagePointCollection();
            var ds = new EnumerableDataSource<VoltagePoint>(_voltagePointCollection);
            //ds.SetXMapping(x => dateAxis.ConvertToDouble(x.Date));
            ds.SetXMapping(x => x.tick);
            ds.SetYMapping(y => y.Voltage);            
            plotter.AddLineGraph(ds, Colors.Green, 2, "Volts"); 
  
            MaxVoltage = 1;
            MinVoltage = 0;
            BackgroundColor = Brushes.White;
            YRangeMin = 0;
            YRangeMax = 30;
            plotter.HorizontalAxis.Remove();
            plotter.LegendVisible = false;
           
        }
