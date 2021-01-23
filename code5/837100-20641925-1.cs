    public class CountryGrouping : List<Country>
    {
        public CountryGrouping(IEnumerable<Country> items) : base(items) { }
        public string Key { get; set; }
    }
