        private Window window;
        public MainWindow()
        {
            InitializeComponent();
        }
        public void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            window = new MainWindow();
        }
        protected override void OnClosed(EventArgs e)
        {
            if (window != null)
            {
                // Call Close on the window you created when the main main closes
                window.Close(); 
            }
            base.OnClosed(e);
        }
