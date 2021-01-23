    public class City
    {
        public string Name { get; set; }
        public string Population { get; set; }
    }
    public static class Mappings
    {
        public static List<City> ConvertToCity(this List<string> names)
        {
            List<City> cities = new List<City>();
            
            foreach (string name in names)
            {
                cities.Add(new City { Name = name });
            }
            return cities;
        }
    }
