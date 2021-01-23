        public MainWindow()
        {
            InitializeComponent();
            var animation = new DoubleAnimation(0, -360, new Duration(TimeSpan.FromSeconds(1)))
            {
                RepeatBehavior = RepeatBehavior.Forever
            };
            var transform = new RotateTransform(0,150,50);
            MyLine.RenderTransform=transform;
            transform.BeginAnimation(RotateTransform.AngleProperty, animation);
        }
