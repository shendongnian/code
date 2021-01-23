    Series series = new Series("Default");
    series.ChartType = SeriesChartType.Point; 
    
    for(int i=0; i<datbase.Count; i++)
    {
      int index = chart.Series[0].Points.AddXY(database[i].x,database[i].y);
      chart.Series[0].Points[index].Label = "Your Label Text";
    }
