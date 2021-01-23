    private void Slider_ValueChanged(object sender, 
        RoutedPropertyChangedEventArgs<double> e)
    {
        // ... Get Slider reference.
        var slider = sender as Slider;
        // ... Get Value.
        double value = slider.Value;
        // ... Set Window Title.
        YourGrid.FontSize = value;
    }
