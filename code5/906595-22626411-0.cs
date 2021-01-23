    public MainWindow()
    {
        InitializeComponent();
        Loaded += (s, e) =>
           {
              DoubleAnimation animation = new DoubleAnimation(200, 500, 
                                              TimeSpan.FromSeconds(0.2));
              animation.AccelerationRatio = 0.1;
              BeginAnimation(Window.TopProperty, animation);
           };
    }
