      tChart1.Aspect.View3D = false;
      tChart1.Legend.Visible = false;
      tChart1.Width = 100;
      tChart1.Height = 300;
      tChart1.Axes.Bottom.MaximumOffset = 1;
    
      Steema.TeeChart.Styles.ColorGrid colorGrid1 = new Steema.TeeChart.Styles.ColorGrid(tChart1.Chart);
    
      const int maxVal = 10;
    
      for (int i = 0; i < 1; i++)
      {
        for (int j = 0; j < maxVal; j++)
        {
          colorGrid1.Add(i, 0, j);
        }
      }
    
      Steema.TeeChart.Styles.Bar bar1 = new Steema.TeeChart.Styles.Bar(tChart1.Chart);
    
      bar1.MultiBar = Steema.TeeChart.Styles.MultiBars.None;
      bar1.Marks.Visible = false;
      bar1.ColorEach = true;
    
      Random y = new Random();
    
      for (int i = 0; i < 100; i++)
      {
        bar1.Clear();
        double tmp = y.Next(maxVal);
    
        int index = colorGrid1.ZValues.IndexOf(tmp);
        colorGrid1.YValues[index] += 1;
    
        bar1.Add(0.5, tmp, colorGrid1.StartColor); 
      }
