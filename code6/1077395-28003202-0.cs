    public void timer_Tick(object sender, object e)
    {
    if (sw.Elapsed < duration)
    {
        Seconds = (int)(duration - sw.Elapsed).TotalSeconds;
        TimeElapsed = String.Format("{0} second(s)", Seconds);
    }
    else
    {
        TimeElapsed = "Times Up";
        timer.Stop();
        new Views.EquationView().OnTimesUp();
    }
    }
