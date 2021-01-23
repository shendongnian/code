    public class CitiesResponse
    {
        public string Status { get; set; }
        public List<City> Result { get; set; }
    }
    var response = JsonConvert.DeserializeObject<CitiesResponse>(jsonString);
    // response.Result is your list of cities
