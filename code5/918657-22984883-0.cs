        DateTime holdStartTime;
        public MainWindow()
        {
            InitializeComponent();
            PreviewMouseDown += new MouseButtonEventHandler(MainWindow_PreviewMouseDown);
            PreviewMouseUp += new MouseButtonEventHandler(MainWindow_PreviewMouseUp);
        }
        void MainWindow_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            holdStartTime = DateTime.Now;
        }
        void MainWindow_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if ((DateTime.Now - holdStartTime).TotalMilliseconds < 1000)
            {
                Console.WriteLine("Do something");
            }
            else
            {
                Console.WriteLine("Do something else");
            } 
        }
