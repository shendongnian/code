    public partial class MainWindow : Window
    {
        List<Point> points;
        Timer reset;
        public MainWindow()
        {
            InitializeComponent();
            points = new List<Point>();
            reset = new Timer { AutoReset = false, Interval = 500 };
            reset.Elapsed += (s, e) =>
            {
                App.Current.Dispatcher.BeginInvoke((Action)(() =>
                {
                    ShapeCanvas.Children.Clear();
                }));
                if (points.Count > 10)
                {
                    double? max_x = null;
                    double? min_x = null;
                    double? max_y = null;
                    double? min_y = null;
                    // evaulate points to determine center
                    foreach (var point in points)
                    {
                        max_x = Math.Max(max_x ?? point.X, point.X);
                        min_x = Math.Min(min_x ?? point.X, point.X);
                        max_y = Math.Max(max_y ?? point.Y, point.Y);
                        min_y = Math.Min(min_y ?? point.Y, point.Y);
                    }
                    var center = new Point((((double)max_x - (double)min_x) / 2) + (double)min_x, (((double)max_y - (double)min_y) / 2) + (double)min_y);
                    var count_r = 0;
                    var sum_r = 0d;
                    var all_r = new List<double>();
                    var quadrands = new int[4];
                    // evaluate points again to determine quadrant and to get all distances and average distance
                    foreach (var point in points)
                    {
                        // distance
                        var r = Math.Sqrt(Math.Pow(point.X - center.X, 2) + Math.Pow(point.Y - center.Y, 2));
                        sum_r += r;
                        count_r += 1;
                        all_r.Add(r);
                        // quadrand
                        quadrands[(point.Y > center.Y ? 1 : 0) + (point.X > center.X ? 2 : 0)] += 1;
                    }
                    var r_avg = sum_r / count_r;
                    if (all_r.Count(r => Math.Abs(r - r_avg) < r_avg * .3) >= count_r * .8 && quadrands.All(q => q > 1))
                    {
                        // you made a circle
                        App.Current.Dispatcher.BeginInvoke((Action)(() =>
                        {
                            ShapeCanvas.Children.Clear();
                            ShapeCanvas.Children.Add(new Ellipse() { Fill = new SolidColorBrush(Colors.Red), Width = 15, Height = 15 });
                            reset.Start();
                        }));
                    }
                }
                points.Clear();
            };
            ShapeCanvas.MouseMove += (s, e) =>
            {
                points.Add(e.GetPosition((Canvas)s));
                reset.Stop();
                reset.Start();
            };
        }
    }
