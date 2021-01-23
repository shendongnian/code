    private void chartTimer_Tick(object sender, EventArgs e)
    {
        if (series.Points.Count() > 1000) series.Points.RemoveAt(0);
        series.Points.Add(wf.BitsPerSecond * 0.000001);
        chart1.ResetAutoValues();
    }
