    private void InitializeChart()
    {
      tChart1.Axes.Right.Grid.Visible = false;
      tChart1.Axes.Right.Maximum = 160.0;
      tChart1.Axes.Right.Minimum = -40;
      tChart1.Axes.Right.Increment = 40;
      tChart1.Axes.Right.Automatic = false;
      tChart1.Axes.Right.AutomaticMinimum = false;
      tChart1.Axes.Right.AutomaticMaximum = false;
      tChart1.Aspect.View3D = false;
      tChart1.Panel.Bevel.Inner = Steema.TeeChart.Drawing.BevelStyles.None;
      tChart1.Panel.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
      tChart1.Axes.Left.Grid.Visible = false;
      tChart1.Axes.Bottom.Grid.Centered = false;
      tChart1.Axes.Bottom.Ticks.Visible = false;
      tChart1.Axes.Left.Automatic = false;
      tChart1.Axes.Left.Minimum = 0;
      tChart1.Axes.Left.Maximum = 100;
      tChart1.Axes.Right.Visible = true;
      var barProduct = new Steema.TeeChart.Styles.Bar();
      barProduct.MultiBar = MultiBars.Side;
      barProduct.Color = Color.Green;
      barProduct.Marks.Visible = false;
      barProduct.Title = "% Vol";
      barProduct.ShowInLegend = true;
      Random rnd = new Random();
      for (int i = 0; i < 10; i++)
      {
        barProduct.Add(rnd.Next(0, 100));
      }
      tChart1.Series.Add(barProduct);
      var barTemperature = new Steema.TeeChart.Styles.Bar();
      barTemperature.MultiBar = MultiBars.Side;
      barTemperature.Color = Color.FromArgb(153, 74, 11);
      barTemperature.Marks.Visible = false;
      barTemperature.VertAxis = VerticalAxis.Right;
      barTemperature.UseOrigin = true;
      barTemperature.Origin = -40;
      barTemperature.Title = "Temperature";
      barTemperature.ShowInLegend = true;
      for (int i = 0; i < 10; i++)
      {
        barTemperature.Add(rnd.Next(-40, 160));
      }
      tChart1.Series.Add(barTemperature);
      tChart1.Panel.Gradient.Visible = false;
      tChart1.Walls.Back.Gradient.Visible = false;
      tChart1.Panel.Color = Color.White;
      tChart1.Walls.Back.Color = Color.White;
    }
