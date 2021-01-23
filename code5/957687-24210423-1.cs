       public partial class MainWindow : Window
    {
        private ObservableCollection<City> cities = new ObservableCollection<City>();
        public MainWindow()
        {
            InitializeComponent();
            cities.Add(new City() { Name = "Boston", State = "MA", Population = 3000000 });
            cities.Add(new City() { Name = "Los Angeles", State = "CA", Population = 7000000 });
            cities.Add(new City() { Name = "Frederick", State = "MD", Population = 65000 });
            cities.Add(new City() { Name = "Houston", State = "TX", Population = 5000000 });
            DataContext = cities;
        }
        class City
        {
            public string State { get; set; }
            public string Name { get; set; }
            public int Population { get; set; }
        }
    }
