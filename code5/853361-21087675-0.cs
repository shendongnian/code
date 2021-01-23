    public struct City
    {
        public string cityName { get; set; }
        public float cityTemp { get; set; }
        public override string ToString()
        {
            return String.Format("{0} {1}", cityName, cityTemp);
        }
    }
    public void DisplayAll(IEnumerable<City> cities)
    {
        foreach (var city in cities)
            Console.WriteLine(city);
    }
