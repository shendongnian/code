    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            //BindCountries();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            BindCountries();
        }
        private void BindCountries()
        {
            var json =
                "{\"type\":\"ok\",\"countries\":[{\"title\":\"Country-1\",\"description\":\"US\",\"status\":\"1\"},{\"title\":\"Country-2\",\"description\":\"Australia\",\"status\":\"0\"},{\"title\":\"Country-3\",\"description\":\"Brazil\",\"status\":\"0\"}]}";
            var countryResult = JsonConvert.DeserializeObject<CountryResult>(json);
            if (countryResult.Type.Equals("ok", StringComparison.InvariantCultureIgnoreCase))
            {
                lstCountries.ItemsSource = countryResult.Countries;
            }
           
        }
    }
    public class CountryResult
    {
        public string Type { get; set; }
        public IEnumerable<Country> Countries { get; set; }
    }
    public class Country
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
    }
