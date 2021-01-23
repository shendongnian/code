    private void chartTimer_Tick(object sender, EventArgs e)
    {
        if (seriesBps.Points.Count() > 150)
            seriesBps.Points.RemoveAt(0);
        seriesBps.Points.Add(wf.BitsPerSecond * 0.000001);
        if (seriesPps.Points.Count() > 150) seriesPps.Points.RemoveAt(0);
        seriesPps.Points.Add(wf.PacketsPerSecond);
        chart1.ResetAutoValues();
    }
