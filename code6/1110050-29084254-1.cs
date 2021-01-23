       for (int i = 0; i <= 17 - 1; i++)
       {
          DataPoint p = new DataPoint(i, i);
          S.Points.Add(p);
       }
       // calculate the total:
       double total = S.Points.Sum(dp => dp.YValues[0]);
       // now we can set the percentages
       foreach (DataPoint p in S.Points)
       {
           p.Label = (100d * p.YValues[0] / total).ToString("0.00") + "%";
       }       
