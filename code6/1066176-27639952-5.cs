    // Dependency Property
    public static readonly DependencyProperty AngleProperty = 
         DependencyProperty.Register( "Angle", typeof(int),
         typeof(RadialGauge), new FrameworkPropertyMetadata(0));
     
    // .NET Property wrapper
    public int Angle
    {
        get { return (int)GetValue(AngleProperty); }
        set { SetValue(AngleProperty, value); }
    }
