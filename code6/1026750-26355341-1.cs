    public MainWindow()
    {
        InitializeComponent();
        _rectangle = new Rectangle
        {
            Stroke = Brushes.Black,
            StrokeThickness = 1
        };
        DrawCanvas.Children.Add(_rectangle); // add it once
    }
    private void MapImageOnMouseMove(object sender, MouseEventArgs e)
    {
        if (_drawmode == DrawMode.Draw)
        {
            var endPoint = e.GetPosition(DrawCanvas);
            _rectangle.Width = Math.Abs(endPoint.X - _startPoint.X);
            _rectangle.Height = Math.Abs(endPoint.Y - _startPoint.Y);
            Canvas.SetLeft(_rectangle, _startPoint.X);
            Canvas.SetTop(_rectangle, _startPoint.Y);
        }
    }
