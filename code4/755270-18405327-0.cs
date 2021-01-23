    private Steema.TeeChart.TChart tChart1; 
    public Form1()
    {
      InitializeComponent();
      tChart1 = new Steema.TeeChart.TChart();
      this.Controls.Add(tChart1);
      tChart1.Left = 100;
      tChart1.Top = 50;
      tChart1.Width = 500;
      tChart1.Height = 350; 
      tChart1.Dock = DockStyle.Fill; 
      InitialzieChart(); 
    }
    private void InitialzieChart()
    {
      Steema.TeeChart.Styles.Bar bar1 = new Steema.TeeChart.Styles.Bar(tChart1.Chart);
      DateTime dt = DateTime.Today;
      Random rnd = new Random();
      bar1.XValues.DateTime = true; 
      //bar1.date
      for (int i = 0; i < 20; i++)
      {
        bar1.Add(dt, rnd.Next(100));
        dt = dt.AddDays(5); 
      }
      
      tChart1.Axes.Bottom.Labels.Angle = 45;
      tChart1.Panel.MarginLeft = 10;
      tChart1.Legend.Alignment = Steema.TeeChart.LegendAlignments.Bottom; 
      AddCustomLabels(); 
    }
    private void AddCustomLabels()
    {
      tChart1.Axes.Bottom.Labels.Items.Clear();
      for (int i = 0; i < tChart1[0].Count; i++)
      {
        tChart1.Axes.Bottom.Labels.Items.Add(tChart1[0].XValues[i], DateTime.FromOADate(tChart1[0].XValues[i]).ToLongDateString()); 
      }
    }
