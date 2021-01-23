    public enum myEnum
    {
        One,
        Two,
        Four,
        Eight
    }
    
    public partial class MainWindow : Window
    {
        private IEnumerable<string> _enumValues;
        public MainWindow()
        {
            InitializeComponent();
    
            _enumValues = ConvertEnumToStrings<myEnum>();
    
            enumCombo.ItemsSource = _enumValues;
        }
    
        private static IEnumerable<string> ConvertEnumToStrings<T>()
        {
            var enumValues = Enum.GetValues(typeof(T))
                .Cast<T>()
                .Select(x => x.ToString())
                .OrderBy(x => x)
                .ToArray();
    
            return enumValues;
        }
    }
