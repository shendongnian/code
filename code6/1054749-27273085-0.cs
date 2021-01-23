        public partial class MainWindow : Window
    {
        public static readonly DependencyProperty BackgroundColorProperty = DependencyProperty.Register(
            "BackgroundColor", typeof (SolidColorBrush), typeof (MainWindow), new PropertyMetadata(default(SolidColorBrush)));
        public SolidColorBrush BackgroundColor
        {
            get { return (SolidColorBrush) GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }
        public MainWindow()
        {
            BackgroundColor = new SolidColorBrush(Colors.LightBlue);
            InitializeComponent();
        }
        private void ChangeBackgroundButton_OnClick(object sender, RoutedEventArgs e)
        {
            BackgroundColor = new SolidColorBrush(Colors.CornflowerBlue);
        }
    }
