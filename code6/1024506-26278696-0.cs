    public class Country
    {
        public int CountryId { get; set; }
        public CurrentPresident President { get; set; }
        public IList<State> States { get; set; }
        public IList<City> Cities { get; set; }
        public Country()
        {
              States = new List<State>();
              Cities =new List<City>();
        }
    }
