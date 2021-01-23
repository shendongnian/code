    StackPanel panel = new StackPanel();
    panel.Children.Add(new Button() { Width = 75, Height = 25 });
    panel.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
    panel.Arrange(new Rect(0, 0, panel.DesiredSize.Width, panel.DesiredSize.Height));
    Title = panel.ActualHeight.ToString();
