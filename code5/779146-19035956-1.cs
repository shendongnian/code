    public partial class DateRangeGridSample : Window
    {
        public ObservableCollection<DateRange> Data { get; set; }
        public DateRangeGridSample()
        {
            InitializeComponent();
            DataContext = Data = new ObservableCollection<DateRange>();
        }
        private void NewRow(object sender, RoutedEventArgs e)
        {
            Data.Add(new DateRange() {StartDate = DateTime.Today, EndDate = DateTime.Today.AddYears(1)});
        }
    }
