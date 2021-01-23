    void Main()
    {
        var response = JsonConvert.DeserializeObject<Response[]>(json); 
        var sorted = response.Select(x => new Year 
        {
            YearNumber = x.Year,
            Month = new Months 
            {
                Apr = x.Apr,
                Aug = x.Aug,
                Dec = x.Dec,
                Feb = x.Feb,
                Jan = x.Jan,
                Jul = x.Jul,
                Jun = x.Jun,
                Mar = x.Mar,
                May = x.May,
                Nov = x.Nov,
                Oct = x.Oct,
                Sep = x.Sep
            }
        });
        
        sorted.Dump();
    }
    
    public class Year
    {
        public int YearNumber { get; set; }
        public Months Month { get; set; }
    }
    public class Months
    {
        public int Jan { get; set; }
        public int Feb { get; set; }
        public int Mar { get; set; }
        public int Apr { get; set; }
        public int May { get; set; }
        public int Jun { get; set; }
        public int Jul { get; set; }
        public int Aug { get; set; }
        public int Sep { get; set; }
        public int Oct { get; set; }
        public int Nov { get; set; }
        public int Dec { get; set; }
    }
    public class Response
    {
        [JsonProperty("year")]
        public int Year { get; set; }
        [JsonProperty("jan")]
        public int Jan { get; set; }
        [JsonProperty("feb")]
        public int Feb { get; set; }
        [JsonProperty("mar")]
        public int Mar { get; set; }
        [JsonProperty("apr")]
        public int Apr { get; set; }
        [JsonProperty("may")]
        public int May { get; set; }
        [JsonProperty("jun")]
        public int Jun { get; set; }
        [JsonProperty("jul")]
        public int Jul { get; set; }
        [JsonProperty("aug")]
        public int Aug { get; set; }
        [JsonProperty("sep")]
        public int Sep { get; set; }
        [JsonProperty("oct")]
        public int Oct { get; set; }
        [JsonProperty("nov")]
        public int Nov { get; set; }
        [JsonProperty("dec")]
        public int Dec { get; set; }
    }
    const string json = @"
    [{
        ""year"":2005,
        ""jan"":0,
        ""feb"":0,
        ""mar"":0,
        ""apr"":6,
        ""may"":93,
        ""jun"":341,
        ""jul"":995,
        ""aug"":1528,
        ""sep"":1725,
        ""oct"":1749,
        ""nov"":1752,
        ""dec"":1752
    },
    {
        ""year"":2006,
        ""oct"":1937,
        ""nov"":1938
    }]";
