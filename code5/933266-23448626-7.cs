        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 10; i++)
            {
                int i1 = i;
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background,
                    new Action(() => Console.WriteLine(i1.ToString())));
            }
        }
