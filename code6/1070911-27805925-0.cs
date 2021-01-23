    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public int RadioGroupValue
        {
            get { return (int)GetValue(RadioGroupValueProperty); }
            set { SetValue(RadioGroupValueProperty, value); }
        }
        public static readonly DependencyProperty RadioGroupValueProperty = DependencyProperty.Register("RadioGroupValue", typeof(int), typeof(MainWindow));
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text == "")
            {
                return;
            }
            RadioButton radioButton = new RadioButton();
            radioButton.Content = textBox1.Text;
            Binding binding = new Binding("RadioGroupValue");
            binding.Source = this;
            binding.Converter = new RadioButtonCheckedConverter();
            binding.ConverterParameter = stackPanel1.Children.Count;
            binding.Mode = BindingMode.TwoWay;
            radioButton.SetBinding(RadioButton.IsCheckedProperty, binding);
            stackPanel1.Children.Add(radioButton);
        }
    }
    class RadioButtonCheckedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int buttonId = (int)parameter, groupValue = (int)value;
            return buttonId == groupValue;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int buttonId = (int)parameter;
            bool isChecked = (bool)value;
            return isChecked ? buttonId : Binding.DoNothing;
        }
    }
