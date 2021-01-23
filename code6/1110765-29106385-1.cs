        public MainWindow()
        {
            InitializeComponent();
            var line = new Line { Stroke = new SolidColorBrush(Colors.Black), StrokeThickness = 5, X1 = 0, Y1 = 0, X2 = 50, Y2 = 50 };
            this.Canvas.Children.Add(line);
        }
