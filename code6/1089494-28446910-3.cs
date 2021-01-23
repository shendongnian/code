    class BaseViewModelCollection : List<BaseViewModel> { }
    class BaseViewModel { }
    class StringViewModel : BaseViewModel
    {
        public string Text { get; set; }
    }
    class ColorViewModel : BaseViewModel
    {
        public Color Color { get; set; }
    }
    class ColorToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return new SolidColorBrush((Color)value);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
