    private void cbStatistics_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cbStatistics.SelectedIndex == 0)
        {
            seriesBps.Enabled = true;
            seriesPps.Enabled = false;
            lblChartMbitSec.Text = string.Format("{0} Mbit/sec", (wf2.BitsPerSecond *          0.000001).ToString("0.##")); // and similarly for the other case below
        }
        else if (cbStatistics.SelectedIndex == 1)
        {
            seriesBps.Enabled = false;
            seriesPps.Enabled = true;
        }
        chart1.ResetAutoValues();
        
    }
