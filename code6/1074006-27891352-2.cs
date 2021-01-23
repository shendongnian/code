    class RegionDB : IEnumerable<String>, IEnumerable
    {
        private IDictionary<String, IEnumerable<City>> continents = new Dictionary<String, IEnumerable<City>>();
        
        public IEnumerable<String> Continents
        {
            get { return this.continents.Keys; }
        }
        
        public IEnumerable<City> this[String continent]
        {
            get
            {
                return this.continents.ContainsKey(continent)
                    ? this.continents[continent]
                    : Enumerable.Empty<City>();
            }
            set
            {
                this.continents[continent] = value ?? Enumerable.Empty<City>();
            }
        }
        
        public RegionDB()
        {
        }
        
        #region IEnumerable<String>
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<String>)this).GetEnumerator();
        }
        
        IEnumerator<String> IEnumerable<String>.GetEnumerator()
        {
            return this.continents.Keys.GetEnumerator();
        }
        
        #endregion
    }
    
    class City
    {
        public String Text { get; set; }
        public String Value { get; set; }
        
        public City(String text, String value)
        {
            this.Text = text;
            this.Value = value;
        }
    }
