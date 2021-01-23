    // Window.xaml.cs
        public MainWindow()
        {
            shapes = new ObservableCollection<Shape>();
            InitializeComponent();
            this.DataContext = this;
            shapes.Add(new Rectangle() { X = 50, Y = 43, H = 15, W = 59 });
            shapes.Add(new Rectangle() { X = 67, Y = 43, H = 20, W = 30 });
            shapes.Add(new Circle() { X = 50, Y = 43, H = 15, W = 59 });
            shapes.Add(new Triangle() { X = 100, Y = 100, H = 40, W = 40, Angle = 20 });
        }
        public ObservableCollection<Shape> shapes { get; set; }
