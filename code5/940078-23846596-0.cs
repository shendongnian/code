    public Shape Shape
    {
        get { return (Shape)GetValue(ShapeProperty); }
        set { SetValue(ShapeProperty, value); }
    }
    public static readonly DependencyProperty ShapeProperty =
            DependencyProperty.Register("Shape", typeof(Shape), typeof(MyControl), new PropertyMetadata(null));
