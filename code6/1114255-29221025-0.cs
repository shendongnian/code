    class City
    {
        public string CityName { get; set; }
        public int Population { get; set; }
    }
    class Program
    {
        public static List<string> configCityNames = new List<string> 
        {
            "New York", "Chicago", "Boston", "San Francisco", "Miami", "etc."
        };
        static void Main(string[] args)
        {
            var cities = new Dictionary<string, City>();
            foreach(var cityName in configCityNames)
                cities.Add(cityName, new City() { CityName = cityName });
            foreach (var city in cities.Values)
                Console.WriteLine(city.CityName);
        }
    }
