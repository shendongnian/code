    public class Data:ModelBase
    {
        public ObservableCollection<string> Countries { get; set; }
        private List<City> _allCities = new List<City>();
        public IEnumerable<City> Cities
        {
            get
            {
                if (_selectedCountry == null)
                    return _allCities;
                return _allCities.Where(c => c.Country == _selectedCountry);
            }
            
        }
        public Data()
        {
            Countries = new ObservableCollection<string>();
            //Fill _allCities and Countries here
        }
        private string _selectedCountry;
        public string SelectedCountry
        {
            get
            {
                return _selectedCountry;
            }
            set
            {
                if (_selectedCountry != value)
                {
                    _selectedCountry = value;
                    OnPropertyChanged("SelectedCountry");
                    OnPropertyChanged("Cities");
                }
            }
        }
    }
    public class City
    {
        public string Country { get; set; }
        public string Name { get; set; }
    }
