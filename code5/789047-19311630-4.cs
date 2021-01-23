    public partial class DoubleUpDown : UserControl
    {
        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(double), typeof(DoubleUpDown), new PropertyMetadata(0.0));
            
        public DoubleUpDown()
        {
            InitializeComponent();
            DataContext = this;
        }
        private void Up_Click(object sender, RoutedEventArgs e)
        {
            Value++;
        }
        private void Down_Click(object sender, RoutedEventArgs e)
        {
            Value--;
        }
    }
