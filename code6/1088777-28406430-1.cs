    const double PERCENT = 0.25;
    DateTime t1 = Convert.ToDateTime(txtB_StartT.Text);
    DateTime t2 = Convert.ToDateTime(txtB_EndT.Text);
    TimeSpan ts = t1.Subtract(t2);
    long tsMinPercent = ts.Ticks + (long)(ts.Ticks * PERCENT);
    var tsAndPercentTot = TimeSpan.FromTicks(tsMinPercent);
    string newTimeStrg = string.Format("{0:d1}:{1:d2}", tsAndPercentTot.Hours, tsAndPercentTot.Minutes);
    txtB_NewDelivT.Text = newTimeStrg;
