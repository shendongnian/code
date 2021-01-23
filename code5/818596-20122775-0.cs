    private EllipseGeometry ball1Geometry = new EllipseGeometry();
    private EllipseGeometry ball2Geometry = new EllipseGeometry();
    private LineGeometry lineGeometry = new LineGeometry();
    public MainWindow()
    {
        InitializeComponent();
        canvas.Children.Add(new Path
        {
            Stroke = Brushes.Black,
            Data = ball1Geometry
        });
        canvas.Children.Add(new Path
        {
            Stroke = Brushes.Black,
            Data = ball2Geometry
        });
        canvas.Children.Add(new Path
        {
            Stroke = Brushes.Black,
            Data = lineGeometry
        });
    }
    ...
    private void UpdateDrawing(
        Point ball1Position, double ball1Radius,
        Point ball2Position, double ball2Radius)
    {
        ball1Geometry.RadiusX = ball1Radius;
        ball1Geometry.RadiusY = ball1Radius;
        ball1Geometry.Center = ball1Position;
        ball2Geometry.RadiusX = ball2Radius;
        ball2Geometry.RadiusY = ball2Radius;
        ball2Geometry.Center = ball2Position;
        lineGeometry.StartPoint = ball1Position;
        lineGeometry.EndPoint = ball2Position;
    }
