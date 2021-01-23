    public Point<DateTime> MyPoint
    {
        get { return (Point<DateTime>) GetValue(PointDependencyProperty ); }
        set { SetValue(PointDependencyProperty, value); }
    }
