    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public int Int32Value
        {
            get { return (int)GetValue(Int32ValueProperty); }
            set { SetValue(Int32ValueProperty, value); }
        }
        public static DependencyProperty Int32ValueProperty =
            DependencyProperty.Register("Int32Value", typeof(int), typeof(MainWindow), new PropertyMetadata(0));
        private void Int32Button_Click(object sender, RoutedEventArgs e)
        {
            int newValue = Int32Value + 1;
            if (newValue > 3)
            {
                newValue = 0;
            }
            Int32Value = newValue;
        }
    }
