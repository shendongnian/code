    public partial class MainWindow : Window
    {
        public static readonly DependencyProperty SliderIndexValueProperty = DependencyProperty.Register(
            "SliderIndexValue", typeof(int), typeof(MainWindow));
        public int SliderIndexValue
        {
            get { return (int)GetValue(SliderIndexValueProperty); }
            set { SetValue(SliderIndexValueProperty, value); }
        }
        public MainWindow()
        {
            InitializeComponent();
            ((IndexToSliderValueConverter)Resources["indexToSliderValueConverter1"]).Slider = slider1;
            SliderIndexValue = 2;
        }
        private void DownButton_Click(object sender, RoutedEventArgs e)
        {
            if (SliderIndexValue > 0)
            {
                SliderIndexValue--;
            }
        }
        private void UpButton_Click(object sender, RoutedEventArgs e)
        {
            if (SliderIndexValue < slider1.Ticks.Count - 1)
            {
                SliderIndexValue++;
            }
        }
    }
