    public class Country
    {
        public int CountryId { get; set; }
        public CurrentPresident President { get; set; }
        public IList<State> States { get; set; }
        public IList<City> Cities { get; set; }
    
        public Country()
        {
           this.CountryId = 0;
           this.CurrentPresident = null; // Country is brand new, no president elected :-)
           this.States = new List<State>();
           this.Cities = new List<City>();
        }
    }
