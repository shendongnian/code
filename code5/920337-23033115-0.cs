    private void button2_Click(object sender, EventArgs e)
    {
        double sum = 0;
        for (int i = 0; i < clickTimes.Count; i++)
        {
            sum += clickTimes[i];
        }
        double avg = sum / clickTimes.Count;
        double frequency = FrequencyFromInterval(avg);
        label1.Text = "Avg. CpS: " + frequency.ToString());
    }
    private double FrequencyFromInterval(double ms)
    {
        return 1000 / ms;
    }
