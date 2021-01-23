    SolidColorBrush solidcolor = GetPixelColor(RightColorPanel.PointToScreen(point));
            
            Color color = Color.FromArgb(
                solidcolor.Color.A,
                solidcolor.Color.R,
                solidcolor.Color.G,
                solidcolor.Color.B);
            LinearGradientBrush brush = new LinearGradientBrush();
            brush.StartPoint = new Point(0, 0);
            brush.EndPoint = new Point(1, 0);
            brush.GradientStops.Add(new GradientStop(Colors.White, 0.0));
            brush.GradientStops.Add(new GradientStop(color, 1));
            MainColorPanel.Background = brush;
