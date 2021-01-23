    class CountryBase
    {
        public string Name { get; protected set; }
    }
    
    class Country: CountryBase
    {
        public string Name { get { return base.Name;} set { base.Name = value;}
    }
