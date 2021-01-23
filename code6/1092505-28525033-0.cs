    public static readonly DependencyProperty AccelerationProperty =
        DependencyProperty.Register(
            "Acceleration", typeof(double), typeof(MainWindow));
    public double Acceleration
    {
        get { return (double)GetValue(AccelerationProperty); }
        set { SetValue(AccelerationProperty, value); }
    }
    ...
    Velocity += Acceleration * dt;
