    public MainWindow() {
                InitializeComponent();
    			this.Camera = new Camera();
    			this.DataContext = this;
            }
    ...
    public Camera Camera { get; set; }
