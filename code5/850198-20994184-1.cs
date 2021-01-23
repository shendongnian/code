    / Get the size of the canvas
    Size size = new Size(surface.ActualWidth, surface.ActualHeight);
    // Measure and arrange elements
    surface.Measure(availableSize);
    surface.Arrange(new Rect(availableSize));
