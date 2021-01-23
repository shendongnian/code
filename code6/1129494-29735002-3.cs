    public partial class SplashScreenWindow : Window
    {
        public readonly static DependencyProperty ValueProgressBarProperty = DependencyProperty.Register(
            "ValueProgressBar", typeof(double), typeof(SplashScreenWindow));
        public double ValueProgressBar
        {
            get { return (double)GetValue(ValueProgressBarProperty); }
            set { SetValue(ValueProgressBarProperty, value); }
        }
        public SplashScreenWindow()
        {
            InitializeComponent();
            Width = SystemParameters.PrimaryScreenWidth / 2.5;
            Height = SystemParameters.PrimaryScreenHeight / 2.5;
        }
    }
