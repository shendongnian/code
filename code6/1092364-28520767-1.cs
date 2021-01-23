    public class PagingInfo
    {
        public int page { get; set; }
        public int pages { get; set; }
        [JsonProperty("per_page")]
        public int ResultsPerPage { get; set; }
        public int total { get; set; }
    }
    public class Region
    {
        public string id { get; set; }
        public string value { get; set; }
    }
    public class AdminRegion
    {
        public string id { get; set; }
        public string value { get; set; }
    }
    public class IncomeLevel
    {
        public string id { get; set; }
        public string value { get; set; }
    }
    public class LendingType
    {
        public string id { get; set; }
        public string value { get; set; }
    }
    public class CountryInfo
    {
        public string id { get; set; }
        public string iso2Code { get; set; }
        public string name { get; set; }
        public Region region { get; set; }
        public AdminRegion adminregion { get; set; }
        public IncomeLevel incomeLevel { get; set; }
        public LendingType lendingType { get; set; }
        public string capitalCity { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
    }
