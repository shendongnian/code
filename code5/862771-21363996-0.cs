    public MyViewModel(){
         Graph1 = new PlotModel();
         var firstSeries = new LineSeries();
         firstSeries.Points.Add(new DataPoint(1, 2));
         firstSeries.Points.Add(new DataPoint(1, 2));
         Graph1.Series.Add(firstSeries);
      }
