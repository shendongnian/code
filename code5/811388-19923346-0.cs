    chart1.Series.Clear();
            for (int i = 0; i < intarr.Length; i++)
            {
                if (chart1.Series.FindByName(strarr[i])== null)
                {
                    Series series = this.chart1.Series.Add(strarr[i]);
                    series.Points.Add(intarr[i]);
                    series.XValueType = ChartValueType.Int32;
                }
            }
