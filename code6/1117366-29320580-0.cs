    chart.Series.Clear();
        chart.Series.Add("series 1");
        chart.Series.Add("series 2");
        for (int i = 0; i < alphabet.Length; i++)
        {
            DataPoint dp = new DataPoint();
            dp.AxisLabel = alphabet[i].ToString();
            dp.YValues = new double[] { freq[i] };
            chart.Series[0].Points.Add(dp);
            
   
            DataPoint dp1 = new DataPoint();
            dp1.AxisLabel = alphabet[i].ToString();
            dp1.YValues = new double[] { 100 };
            chart.Series[1].Points.Add(dp1);
        }
