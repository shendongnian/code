    public partial class MainWindow : Window
    {
        private List<Number> m_ListViewItems;
        public List<Number> ListViewItems
        {
            get { return m_ListViewItems; }
            set { m_ListViewItems = value; }
        }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            ListViewItems = new List<Number>();
            ListViewItems.Add(new Number() { NumberValue = 1 });
            ListViewItems.Add(new Number() { NumberValue = 2 });
            ListViewItems.Add(new Number() { NumberValue = 3 });
            ListViewItems.Add(new Number() { NumberValue = 4 });
        }
    }
    public class Number
    {
        private int m_NumberValue;
        public int NumberValue
        {
            get { return m_NumberValue; }
            set { m_NumberValue = value; }
        }
    }
    public class NumberToBGColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var number = (int)value;
            if (number % 2 == 0)
                return "Gray";
            else
                return "Yellow";
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
