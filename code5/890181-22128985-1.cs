    for (int x = 0; x < 51; x++)
    {
        for (int y = 0; y < 51; y++)
        {
            var rect = new Rectangle
            {
                Stroke = Brushes.White,
                StrokeThickness = 1,
                Width=1,
                Height=1
            };
            if (x == 0 & y == 0)
            {
                rect.Stroke = Brushes.LimeGreen;
            }
            if (x == 50 & y == 50)
            {
                rect.Stroke = Brushes.LimeGreen;
            }
            Canvas.SetLeft(rect, x);
            Canvas.SetTop(rect, y);
            youCanvasNameHere.Children.Add(rect);
        }
    }
