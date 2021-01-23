    private Point position; // in pixels
    private Vector velocity; // in pixels per second
    private Vector acceleration; // in pixels per square second
    private DateTime time;
    public MainWindow()
    {
        InitializeComponent();
        Loaded += OnLoaded;
    }
    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        position = new Point(100, 100);
        velocity = new Vector(50, -50); // y direction is downwards
        acceleration = new Vector(0, 20); // y direction is downwards
        time = DateTime.Now;
        CompositionTarget.Rendering += OnRendering;
    }
    private void OnRendering(object sender, EventArgs e)
    {
        var t = DateTime.Now;
        var dt = (t - time).TotalSeconds;
        time = t;
        position += velocity * dt;
        velocity += acceleration * dt;
        projectileGeometry.Center = position;
        if (position.Y > ActualHeight)
        {
            CompositionTarget.Rendering -= OnRendering;
        }
    }
