    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }
        void MainWindow_Loaded(object sMainWindow, RoutedEventArgs eMainWindow)
        {
            var task = new Task(() =>
                Debug.WriteLine("Task"));
            var scheduler = TaskScheduler.FromCurrentSynchronizationContext();
            var window1 = new Window();
            window1.Loaded += (sWindow1, eWindow1) =>
            {
                // Deadlock in WPF
                task.RunSynchronously(scheduler);
                Debug.WriteLine("Done!");
            };
            window1.Show();
        }
    }
