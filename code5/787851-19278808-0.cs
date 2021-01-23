    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        public HandIndicatorStates State
        {
            get { return HandIndicatorStates.Top; }
        }
    }
    public enum HandIndicatorStates
    {
        Left = 0,
        Right = 1,
        Top = 2,
        Bottom = 3,
        None = 4
    }
    public class StateToDockEnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, 
                object parameter, System.Globalization.CultureInfo culture)
        {
            HandIndicatorStates state = (HandIndicatorStates)value;
            if (state == HandIndicatorStates.None)
                return null; //??
            // Map from HandIndicatorStates to Dock enum by name.
            var dock = Enum.Parse(typeof(Dock), state.ToString());
            return dock;
        }
        public object ConvertBack(object value, 
            Type targetType, object parameter, 
            System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
