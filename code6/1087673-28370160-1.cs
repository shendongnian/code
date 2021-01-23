    public static readonly DependencyProperty SliderValueProperty =
        DependencyProperty.Register("SliderValue", typeof(double), typeof(MainWindow),
        new PropertyMetadata(default(double), null, CoerceSliderValue));
    private static object CoerceSliderValue(DependencyObject d, object value)
    {
        // Of course good idea would be to be have min/max as CLR properies
        // in your class and bind slider with those values.
        // So, that you can have refer to those values directly here.
        double min = ((MainWindow)d).slider.Minimum;
        double max = ((MainWindow)d).slider.Maximum;
        double passedValue = (double)value;
    
        if (passedValue < min)
        {
            return min;
        }
        else if (passedValue > max)
        {
            return max;
        }
        return passedValue;
    }
    
    private void Slider_OnValueChanged(object sender, 
                                       RoutedPropertyChangedEventArgs<double> e)
    {
        CoerceValue(SliderValueProperty);
    }
 
