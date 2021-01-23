    public MainWindow()
    {
        InitializeComponent();
        var vm = new ViewModel();
        vm.Drawings = new ObservableCollection<Drawing>();
        vm.Drawings.Add(new Drawing
            {
                Geometry = new EllipseGeometry(new Point(100, 100), 50, 30),
                Fill = Brushes.LightBlue,
                Stroke = Brushes.Blue,
                StrokeThickness = 2
            });
        vm.Drawings.Add(new Drawing
        {
            Geometry = new RectangleGeometry(new Rect(50, 150, 100, 60)),
            Fill = Brushes.LightGreen,
            Stroke = Brushes.Green,
            StrokeThickness = 2
        });
        DataContext = vm;
    }
