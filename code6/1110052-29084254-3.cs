       for (int i = 0; i <= index - 1; i++)
       {
          S.Points.AddXY(project[i], projTime[i]);
       }
       // calculate the total:
       double total = S.Points.Sum(dp => dp.YValues[0]);
       // now we can set the percentages
       foreach (DataPoint p in S.Points)
       {
           p.Label = (100d * p.YValues[0] / total).ToString("0.00") + "%"; // my format
       }       
