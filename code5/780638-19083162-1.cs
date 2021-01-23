    public partial class Address
    {
        public int Id { get; set; }
        public ObservableCollection<Country> Countries{get;set;}
        public Nullable<int> CountryId { get; set; }
        public ObservableCollection<City> Cities{get;set;}
        public Nullable<int> CityId { get; set; }
        public string Details { get; set; }
        public Nullable<bool> IsDefault { get; set; }
        public Nullable<int> PersonId { get; set; }
    }
