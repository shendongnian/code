            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "hh:mm";
            Series s1 = new Series("s1");
            s1.XValueType = ChartValueType.DateTime;
            s1.Points.AddXY(Convert.ToDateTime("10:01").ToOADate(), 1);
            s1.Points.AddXY(Convert.ToDateTime("10:02").ToOADate(), 2);
            s1.Points.AddXY(Convert.ToDateTime("10:03").ToOADate(), 3);
            s1.Points.AddXY(Convert.ToDateTime("10:04").ToOADate(), 4);
            s1.Points.AddXY(Convert.ToDateTime("10:07").ToOADate(), 5);            
            chart1.Series.Add(s1);
            
            Series s2 = new Series("s2");
            s2.XValueType = ChartValueType.DateTime;
            s2.Points.AddXY(Convert.ToDateTime("10:01").ToOADate(), 10);
            s2.Points.AddXY(Convert.ToDateTime("10:02").ToOADate(), 9);
            s2.Points.AddXY(Convert.ToDateTime("10:05").ToOADate(), 8);
            s2.Points.AddXY(Convert.ToDateTime("10:06").ToOADate(), 7);
            s2.Points.AddXY(Convert.ToDateTime("10:09").ToOADate(), 6);
            chart1.Series.Add(s2);
