    public static readonly DependencyProperty AccelerationProperty =
        DependencyProperty.Register(
            "Acceleration", typeof(Vector), typeof(MainWindow));
    public Vector Acceleration
    {
        get { return (Vector)GetValue(AccelerationProperty); }
        set { SetValue(AccelerationProperty, value); }
    }
    ...
    Velocity += Acceleration * dt;
