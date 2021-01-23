    public partial class MainWindow : Window
    {
        private PolyLineSegment segment;
        public MainWindow()
        {
            InitializeComponent();
            segment = new PolyLineSegment();
            segment.IsStroked = true;
            segment.Points.Add(new Point(100, 100));
            segment.Points.Add(new Point(200, 200));
            var figure = new PathFigure { StartPoint = new Point(0, 0) };
            figure.Segments.Add(segment);
            geometry.Figures.Add(figure);
        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            segment.Points[0] = e.GetPosition((IInputElement)sender);
        }
    }
