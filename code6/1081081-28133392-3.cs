    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public Fruit Value
        {
            get { return (Fruit)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        public static DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(Fruit), typeof(MainWindow), new PropertyMetadata(Fruit.Apple));
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            Value = (Fruit)comboBox.SelectedValue;
        }
    }
