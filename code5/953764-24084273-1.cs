        public MainWindow() // Constructor
        {
            InitializeComponent();
            ContextMenuButton.ContextMenu.Opened += (sender, args) => Debug.Print("Opening #2");
            ContextMenuButton.ContextMenu.Closed += (sender, args) => Debug.Print("Closing #2");
        }
