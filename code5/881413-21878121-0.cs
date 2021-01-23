    public double ZoomSlider
    {
       get { return (double)GetValue(ZoomSliderProperty); }
       set { SetValue(ZoomSliderProperty, value); }
    }
    
    // Using a DependencyProperty as the backing store for ZoomSlider.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty ZoomSliderProperty =
                DependencyProperty.Register("ZoomSlider", typeof(double), typeof(MainWindow), new PropertyMetadata(2d));
