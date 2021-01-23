    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainCanvas.Loaded += MainCanvas_Loaded;
        }
        void MainCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            Init();
        }
        private void Init()
        {
            const int FirefliesCount = 100;
            Random Randomer = new Random();
            for (int i = 0; i < FirefliesCount; ++i)
            {
                Firefly CurrentFirefly = new Firefly();
                CurrentFirefly.Speed = Randomer.Next(1, 3);
                CurrentFirefly.Body = new Ellipse();
                CurrentFirefly.Body.Margin = new Thickness(Randomer.Next(10, (int)MainCanvas.ActualWidth - 10),
                                                           Randomer.Next(10, (int)MainCanvas.ActualHeight - 10),
                                                           0, 0);
                CurrentFirefly.Body.Fill = Brushes.Black;
                CurrentFirefly.Body.Height = MainCanvas.ActualHeight / 4;
                CurrentFirefly.Body.Width = 1.5 * CurrentFirefly.Body.Height;
                MainCanvas.Children.Add(CurrentFirefly.Body);
            }
        }
    }
