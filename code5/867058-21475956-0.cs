    var panel = new StackPanel();
    //panel.MaxWidth = 100; //if you control has dynamic sizing
    //panel.MaxHeight = 100;
    panel.Children.Add(view);
    var infinitySize = double.PositiveInfinity,double.PositiveInfinity;
    panel.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
    panel.Arrange(new Rect(0, 0, panel.DesiredSize.Width, panel.DesiredSize.Width));
    view.UpdateLayout();
