    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            SelectedWeekday = Weekdays.Tuesday;
        }
        private Weekdays _selectedWeekday;
        public Weekdays SelectedWeekday
        {
            get { return _selectedWeekday; }
            set
            {
                _selectedWeekday = value;
                if(PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("SelectedWeekday"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
    [Flags]
    public enum Weekdays
    {
        Monday = 1,
        Tuesday = 2,
        Wednesday = 4,
        Thursday = 8,
        Friday = 16,
        Saturday = 32,
        Sunday = 64
    }
    public class WeekdayConverter : IValueConverter, INotifyPropertyChanged
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var day = (Weekdays)value;
            if ((day & Weekday) != 0)
                return true;
            return false;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //Implement convertback
            throw new NotImplementedException();
        }
        private Weekdays _weekday;
        public Weekdays Weekday
        {
            get { return _weekday; }
            set
            {
                _weekday = value;
                if(PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Weekday"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
