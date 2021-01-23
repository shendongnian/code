    private void chartTimer_Tick(object sender, EventArgs e)
    {
        series.Points.Add(wf.BitsPerSecond * 0.000001);
        if (series.Points.Count > someLimit) series.Points.RemoveAt(0);
        chart1.ResetAutoValues();
    }
