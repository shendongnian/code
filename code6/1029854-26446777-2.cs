    slider.ValueChanged += (s, e) =>
    {
        var newFactor = e.NewValue;
        map.Opacity = newFactor;
        //Color newColor = Color.FromRgb((Byte)(newFactor * R), (Byte)(newFactor * G), (Byte)(newFactor * B));
        //plotter.Background = new SolidColorBrush(newColor);
    }
    
