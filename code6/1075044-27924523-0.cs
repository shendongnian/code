    public class Country
    {
        // properties of a Country:
        public int Population {get; private set;}
        public string Units {get; private set;}
        // etc.
        // Factory method/fields follows
        // storage of created countries
        private static Dictionary<string, Country> _Countries = new Dictionary<string,Country>();
        
        public static Country GetCountry(string name)
        {
            Country country;
            if(_Countries.TryGetValue(name, out country))
                return country;
            //else
            country = new Country();
            // load data from external source
            _Countries[name] = country;
            return country;
        }
        
        public static Country France { get {return GetCountry("France");} }
        public static Country Germany { get {return GetCountry("Germany");} }
    }
