    public partial class MainWindow : Window
    {
        public ObservableDataSource<Point> source1 = null;
                       
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Create source         
            source1 = new ObservableDataSource<Point>();
            // Set identity mapping of point in collection to point on plot
            source1.SetXYMapping(p => p);
           
            // Add the graph. Colors are not specified and chosen random
            plotter.AddLineGraph(source1, 2, "Data row");
            // Force everyting to fit in view
            plotter.Viewport.FitToView();
            // Start computation process in second thread
            Thread simThread = new Thread(new ThreadStart(Simulation));
            simThread.IsBackground = true;
            simThread.Start();
        }
        private void Simulation()
        {
            int i = 0;
            while (true)
            {
                Point p1 = new Point(i * i, i);
                source1.AppendAsync(Dispatcher, p1);
                i++;
                Thread.Sleep(1000);
            }
        }
    }
