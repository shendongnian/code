    Deployment.Current.Dispatcher.BeginInvoke(() =>
    {
        var smalltilevar = new smalltile();
        smalltilevar.day = DateTime.Now.Day.ToString();
        smalltilevar.dayofweek = DateTime.Now.DayOfWeek.ToString();
        smalltilevar.Measure(new Size(159, 159));
        smalltilevar.Arrange(new Rect(0, 0, 159, 159));
    });
