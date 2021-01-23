    private Storyboard _storyboard = new Storyboard();
    private DoubleAnimation _animation = new DoubleAnimation { Duration = TimeSpan.FromSeconds(0.1) };
    public MainPage()
    {
        this.InitializeComponent();
        Storyboard.SetTarget(_animation, this.BackgroundImage);
        Storyboard.SetTargetProperty(_animation, "(Canvas.Left)");
        _storyboard.Children.Add(_animation);
        this.MySlider.ValueChanged += (s, e) =>
        {
            _animation.To = this.MySlider.Value;
            _storyboard.Begin();
        };
    }
