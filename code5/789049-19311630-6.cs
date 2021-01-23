        public partial class Point2DEditorView : UserControl
    {
        public Point2D Point
        {
            get { return (Point2D)GetValue(PointProperty); }
            set { SetValue(PointProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Point.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PointProperty =
            DependencyProperty.Register("Point", typeof (Point2D), typeof (Point2DEditorView),
                new PropertyMetadata(new Point2D {X = 10, Y = 20}));
        public Point2DEditorView()
        {
            InitializeComponent();
        }
    }
