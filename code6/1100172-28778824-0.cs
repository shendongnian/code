    for (int i = 0; i < 100000; i++)
    {
        labelToShow.Text = i.ToString(); // live update of information on the GUI
        labelToShow.Invalidate();
        Application.DoEvents();
        double s1 = rnd.NextDouble();
        double s2 = rnd.NextDouble();
        w = Math.Sqrt(-2 * Math.Log(s1)) * Math.Cos(2 * Math.PI * s2);
    }
