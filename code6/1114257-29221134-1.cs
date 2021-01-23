    class Program
    {
        static void Main()
        {
            List<string> configCityNames = new List<string> {
                "New York", "Chicago", "Boston", "San Francisco", "Miami", "etc."
            };
    
            List<City> cities = configCityNames.ConvertToCity();
        }
    }
