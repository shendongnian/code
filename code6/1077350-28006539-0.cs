    var model = new PlotModel { Title = "Test Mouse Events" };
    var s1 = new LineSeries();
    model.Series.Add(s1);
    double x;
    s1.MouseDown += (s, e) =>
        {
            x = (s as LineSeries).InverseTransform(e.Position).X;
        };
