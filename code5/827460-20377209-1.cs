    public class Data
    {
        [JsonProperty("PeriodEnd")]
        public DateTime PeriodEndDate { get; set; }
        [JsonProperty("PeriodStart")]
        public DateTime PeriodStartDate { get; set; }
        public DateTime ResetDate { get; set; }
        public DateTime PayDate { get; set; }
    }
