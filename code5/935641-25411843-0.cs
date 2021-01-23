        public MainWindow()
        {
            InitializeComponent();
            CompositionTarget.Rendering += OnRendering;
        }
        void OnRendering(object sender, EventArgs e)
        {
            Application.Current.Dispatcher.BeginInvoke(
               DispatcherPriority.Background,
               new Action(CommandManager.InvalidateRequerySuggested));
        }
