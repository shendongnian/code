    public MainWindow() {
          InitializeComponent();
          this.Loaded += MainWindow_Loaded;
          _timer.Interval = TimeSpan.FromMilliseconds(100);
          _timer.Start();
          _timer.Tick += _timer_Tick;
        }
    
        private void _timer_Tick(object sender, EventArgs e) {
          var newX = _bezierSeg.Point1.X + .1;
          _bezierSeg.Point1 = new Point(Math.Sin(newX) * 12, 0);
        }
    
        private DispatcherTimer _timer = new DispatcherTimer();
    
        private BezierSegment _bezierSeg = new BezierSegment();
    
        private void MainWindow_Loaded(object sender, RoutedEventArgs e) {
          var arcPath = new Path();
          var figure = new PathFigure();
    
          figure.StartPoint = new Point(0, 0);
          var Point1 = new Point(textblock1.ActualHeight, 0);
          var Point2 = new Point(textblock1.ActualWidth - 30, textblock1.ActualHeight - 20);
          var Point3 = new Point(textblock1.ActualWidth, textblock1.ActualHeight);
    
          _bezierSeg.Point1 = Point1;
          _bezierSeg.Point2 = Point2;
          _bezierSeg.Point3 = Point3;
    
          var myPathSegmentCollection = new PathSegmentCollection();
    
          myPathSegmentCollection.Add(_bezierSeg);
          figure.Segments = myPathSegmentCollection;
    
          var pathCollection = new PathFigureCollection();
          pathCollection.Add(figure);
    
          var pathGeometry = new PathGeometry();
          pathGeometry.Figures = pathCollection;
    
          arcPath.Stroke = new SolidColorBrush(Colors.Red);
          arcPath.Fill = new SolidColorBrush(Colors.Yellow);
          arcPath.StrokeThickness = 2;
    
          arcPath.Data = pathGeometry;
          drawingCanvas.Children.Add(arcPath);
        }
