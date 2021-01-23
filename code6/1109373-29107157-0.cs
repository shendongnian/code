    public class CityDTO
    {
        public string CityName { get; set; }
        public string StateName { get; set; }
        public IEnumerable<string> Trainstations { get; set; } //changed from List<> to IEnumerable<> 
    }
