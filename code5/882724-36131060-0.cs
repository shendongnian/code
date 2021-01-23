        public static void Refresh(this Chart chart) // update changed data
        {
            chart.Series[0].Points.AddXY(1, 1);
            chart.Update();
            chart.Series[0].Points.RemoveAt(chart.Series[0].Points.Count-1);
        }
