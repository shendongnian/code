    class CityResponse
    {
        public string status { get; set; }
        public object result
        {
            get { return null; }
            set 
            {
                cities = new List<City>();
                if (value.GetType() == typeof(JArray))
                {
                    cities = ((JArray)value).ToObject<List<City>>();
                    return;
                }
                if (value.GetType() != typeof(JObject)) 
                    return;
                cities.Add(((JObject)value).ToObject<City>());
            }
        }
        public string message { get; set; }
        public List<City> cities { get; internal set; }
    }
