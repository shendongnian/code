    public class CityDTO
    {
        public string CityName { get; set; }
        public string StateName { get; set; }
        public IQueryable<string> Trainstations { get; set; } // changed to IQueryable
    }
